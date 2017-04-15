using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValmodSkillParser
{
    public class FinalRecipe
    {
        public string WildcardForgeCategory { get; set; }
        public string CraftTool { get; set; }
        public string CraftArea { get; set; }
        public bool AvailableWithoutStation { get; set; }
        public List<FinalRecipeComponent> RecipeComponents { get; set; }

        public FinalRecipe()
        {
            RecipeComponents = new List<FinalRecipeComponent>();
        }
    }
}
