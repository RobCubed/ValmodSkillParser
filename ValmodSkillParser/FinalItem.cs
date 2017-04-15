using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValmodSkillParser
{
    public class FinalItem
    {
        public string ItemName { get; set; }
        public string EnglishItemName { get; set; }
        public List<FinalRecipe> Recipes { get; set; }
        public string QuestRewardFrom { get; set; }
        public string SkillRequired { get; set; }
        public int SkillLevelRequired { get; set; }

        public FinalItem()
        {
            Recipes = new List<FinalRecipe>();
        }
    }
}
