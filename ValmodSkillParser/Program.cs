using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static ValmodSkillParser.Quest;

namespace ValmodSkillParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var LocalizationList = new List<string[]>();

            var Localizations = from line in File.ReadAllLines("Localization.txt").Skip(1)
                                let columns = line.Split(',')
                                where !String.IsNullOrWhiteSpace(line)
                                select new LocalizationSet
                                {
                                    Key = columns[0] ?? "",
                                    Source = columns[1] ?? "",
                                    Context = columns[2] ?? "",
                                    Changes = columns[3] ?? "",
                                    English = columns[4] ?? ""
                                };

            Quests quests = null;
            string questPath = "quests.xml";
            XmlSerializer questSerializer = new XmlSerializer(typeof(Quests));
            StreamReader questReader = new StreamReader(questPath);
            quests = (Quests)questSerializer.Deserialize(questReader);
            questReader.Close();

            Items items = null;
            string itemPath = "items.xml";
            XmlSerializer itemSerializer = new XmlSerializer(typeof(Items));
            StreamReader itemReader = new StreamReader(itemPath);
            items = (Items)itemSerializer.Deserialize(itemReader);
            itemReader.Close();

            Recipes recipes = null;
            string recipePath = "recipes.xml";
            XmlSerializer recipeSerializer = new XmlSerializer(typeof(Recipes));
            StreamReader recipeReader = new StreamReader(recipePath);
            recipes = (Recipes)recipeSerializer.Deserialize(recipeReader);
            recipeReader.Close();


            Progression progression = null;
            string progressionPath = "progression.xml";
            XmlSerializer progressionSerializer = new XmlSerializer(typeof(Progression));
            StreamReader progressionReader = new StreamReader(progressionPath);
            progression = (Progression)progressionSerializer.Deserialize(progressionReader);
            progressionReader.Close();


            var FinalItems = new List<FinalItem>();

            foreach (var item in items.Item)
            {
                var finalItem = new FinalItem();
                finalItem.EnglishItemName = GetItemEnglishName(item.Name, Localizations);
                finalItem.ItemName = item.Name;

                var prog = progression.Skills.Crafting_skill;
                foreach (var p in prog)
                {
                    var recipeP = p.Recipe.FirstOrDefault(r => r.Name.Equals(item.Name));
                    if (recipeP != null)
                    {
                        Debug.WriteLine("\t" + p.Name + " " + recipeP.Unlock_level);
                        finalItem.SkillLevelRequired = Int32.Parse(recipeP.Unlock_level);
                        finalItem.SkillRequired = p.Name;
                    }
                }
                FinalItems.Add(finalItem);
            }


            //recipes without a match to an item
            foreach (var rec in recipes.Recipe)
            {
                var fi = FinalItems.FirstOrDefault(f => f.ItemName.Equals(rec.Name));

                if (fi == null)
                {
                    FinalItem item = new FinalItem();
                    item.ItemName = rec.Name;
                    item.EnglishItemName = GetItemEnglishName(item.ItemName, Localizations);
                    FinalItems.Add(item);
                }
            }

            // check perks
            foreach (var item in FinalItems)
            {
                GetPerkDetails(item, progression);
                GetQuestRewardFrom(item, quests);
                GetCraftingDetails(item, recipes, progression);
            }


            // output json
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(FinalItems);
            System.IO.File.WriteAllText(@"recipes.json", json);

            Debug.WriteLine("DERP");
        }

        private static void GetQuestRewardFrom(FinalItem item, Quests quests)
        {
            foreach (var q in quests.Quest)
            {
                if (q.Reward.Count > 1)
                {
                    foreach (var reward in q.Reward)
                    {
                        if (reward.Type.Equals("Recipe"))
                        {
                            if (reward.Id.Equals(item.ItemName))
                            {
                                item.QuestRewardFrom = q.Name;
                            }
                        }
                    }
                }
            }
        }

        private static void GetPerkDetails(FinalItem item, Progression progression)
        {
            RecipeInternal match = new RecipeInternal();
            foreach (var perk in progression.Skills.Perk)
            {
                match = perk.Recipe.FirstOrDefault(m => m.Name.Equals(item.ItemName));
                if (match == null) continue;
                item.SkillLevelRequired = Int32.Parse(match.Unlock_level);
                item.SkillRequired = perk.Name;
            }

            foreach (var skill in progression.Skills.Player_skill)
            {
                match = skill.Recipe.FirstOrDefault(m => m.Name.Equals(item.ItemName));
                if (match == null) continue;
                item.SkillLevelRequired = Int32.Parse(match.Unlock_level);
                item.SkillRequired = skill.Name;
            }
        }

        private static string GetItemEnglishName(string itemName, IEnumerable<LocalizationSet> localizations)
        {
            var localization = localizations.FirstOrDefault(l => l.Key.Equals(itemName));
            if (localization == null) return "";
            return localization.English;
        }

        private static void GetCraftingDetails(FinalItem finalItem, Recipes recipes, Progression prog)
        {
            var recipe = recipes.Recipe.Where(r => r.Name.Equals(finalItem.ItemName));
            if (recipe.Count() < 1) return;

            foreach (var rx in recipe)
            {
                Debug.WriteLine(rx.Name);
                if (rx.Name.Equals("workstationCombine"))
                {
                    Debug.WriteLine("Okay found workstationCombine");
                }
                var finalRecipe = new FinalRecipe();
                bool result = false;
                if (!String.IsNullOrEmpty(rx.Wildcard_forge_category))
                {
                    finalRecipe.WildcardForgeCategory = rx.Wildcard_forge_category;
                    Debug.Write(rx.Wildcard_forge_category + " ");
                    result = true;
                }
                if (!String.IsNullOrEmpty(rx.Craft_tool))
                {
                    finalRecipe.CraftTool = rx.Craft_tool;
                    Debug.Write(rx.Craft_tool + " ");
                    result = true;
                }
                if (!String.IsNullOrEmpty(rx.Craft_area))
                {
                    finalRecipe.CraftArea = rx.Craft_area;
                    Debug.Write(rx.Craft_area + " ");
                    result = true;
                }
                if (!result)
                {
                    finalRecipe.AvailableWithoutStation = true;
                    Debug.Write("(Available without station)");
                }
                
                foreach (var ingredient in rx.Ingredient)
                {
                    finalRecipe.RecipeComponents.Add(new FinalRecipeComponent()
                    {
                        ItemName = ingredient.Name,
                        Quantity = Int32.Parse(ingredient.Count)
                    });
                }
                finalItem.Recipes.Add(finalRecipe);
            }
        }

    }
}
