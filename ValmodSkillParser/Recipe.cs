using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ValmodSkillParser
{
    [XmlRoot(ElementName = "recipe")]
    public class Recipe
    {
        [XmlElement(ElementName = "wildcard_forge_category")]
        public string Wildcard_forge_category { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "tooltip")]
        public string Tooltip { get; set; }
        [XmlAttribute(AttributeName = "craft_time")]
        public string Craft_time { get; set; }
        [XmlAttribute(AttributeName = "craft_exp_gain")]
        public string Craft_exp_gain { get; set; }
        [XmlElement(ElementName = "ingredient")]
        public List<Ingredient> Ingredient { get; set; }
        [XmlAttribute(AttributeName = "craft_area")]
        public string Craft_area { get; set; }
        [XmlAttribute(AttributeName = "material_based")]
        public string Material_based { get; set; }
        [XmlAttribute(AttributeName = "craft_tool")]
        public string Craft_tool { get; set; }
    }

    [XmlRoot(ElementName = "ingredient")]
    public class Ingredient
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "recipes")]
    public class Recipes
    {
        [XmlElement(ElementName = "recipe")]
        public List<Recipe> Recipe { get; set; }
    }

}
