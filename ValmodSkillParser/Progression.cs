using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ValmodSkillParser
{
    [XmlRoot(ElementName = "player")]
    public class Player
    {
        [XmlAttribute(AttributeName = "max_level")]
        public string Max_level { get; set; }
        [XmlAttribute(AttributeName = "exp_to_level")]
        public string Exp_to_level { get; set; }
        [XmlAttribute(AttributeName = "experience_multiplier")]
        public string Experience_multiplier { get; set; }
        [XmlAttribute(AttributeName = "skill_points_per_level")]
        public string Skill_points_per_level { get; set; }
        [XmlAttribute(AttributeName = "skill_point_multiplier")]
        public string Skill_point_multiplier { get; set; }
    }

    [XmlRoot(ElementName = "multiply")]
    public class Multiply
    {
        [XmlAttribute(AttributeName = "skill_level")]
        public string Skill_level { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "perk_level")]
        public string Perk_level { get; set; }
    }

    [XmlRoot(ElementName = "effect")]
    public class Effect
    {
        [XmlElement(ElementName = "multiply")]
        public List<Multiply> Multiply { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "setvalue")]
        public List<Setvalue> Setvalue { get; set; }
        [XmlElement(ElementName = "add")]
        public List<Add> Add { get; set; }
    }

    [XmlRoot(ElementName = "setvalue")]
    public class Setvalue
    {
        [XmlAttribute(AttributeName = "skill_level")]
        public string Skill_level { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "perk_level")]
        public string Perk_level { get; set; }
    }

    [XmlRoot(ElementName = "player_skill")]
    public class Player_skill
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
        [XmlAttribute(AttributeName = "description_key")]
        public string Description_key { get; set; }
        [XmlAttribute(AttributeName = "title_key")]
        public string Title_key { get; set; }
        [XmlAttribute(AttributeName = "exp_to_level")]
        public string Exp_to_level { get; set; }
        [XmlAttribute(AttributeName = "group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "recipe")]
        public List<RecipeInternal> Recipe { get; set; }
        [XmlAttribute(AttributeName = "experience_multiplier")]
        public string Experience_multiplier { get; set; }
    }

    [XmlRoot(ElementName = "requirement")]
    public class Requirement
    {
        [XmlAttribute(AttributeName = "perk_level")]
        public string Perk_level { get; set; }
        [XmlAttribute(AttributeName = "required_skill_name")]
        public string Required_skill_name { get; set; }
        [XmlAttribute(AttributeName = "required_skill_level")]
        public string Required_skill_level { get; set; }
        [XmlAttribute(AttributeName = "skill_level")]
        public string Skill_level { get; set; }
        [XmlAttribute(AttributeName = "required_player_level")]
        public string Required_player_level { get; set; }
    }

    [XmlRoot(ElementName = "add")]
    public class Add
    {
        [XmlAttribute(AttributeName = "perk_level")]
        public string Perk_level { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "skill_level")]
        public string Skill_level { get; set; }
        [XmlAttribute(AttributeName = "required_skill_name")]
        public string Required_skill_name { get; set; }
        [XmlAttribute(AttributeName = "required_skill_level")]
        public string Required_skill_level { get; set; }
    }

    [XmlRoot(ElementName = "perk")]
    public class Perk
    {
        [XmlElement(ElementName = "requirement")]
        public List<Requirement> Requirement { get; set; }
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
        [XmlAttribute(AttributeName = "description_key")]
        public string Description_key { get; set; }
        [XmlAttribute(AttributeName = "title_key")]
        public string Title_key { get; set; }
        [XmlAttribute(AttributeName = "max_level")]
        public string Max_level { get; set; }
        [XmlAttribute(AttributeName = "skill_point_cost_multiplier")]
        public string Skill_point_cost_multiplier { get; set; }
        [XmlAttribute(AttributeName = "skill_point_cost_per_level")]
        public string Skill_point_cost_per_level { get; set; }
        [XmlAttribute(AttributeName = "always_fire")]
        public string Always_fire { get; set; }
        [XmlAttribute(AttributeName = "group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "recipe")]
        public List<RecipeInternal> Recipe { get; set; }
        [XmlAttribute(AttributeName = "passive_effect")]
        public string Passive_effect { get; set; }
    }

    [XmlRoot(ElementName = "recipe")]
    public class RecipeInternal
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "unlock_level")]
        public string Unlock_level { get; set; }
    }

    [XmlRoot(ElementName = "action_skill")]
    public class Action_skill
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
        [XmlAttribute(AttributeName = "description_key")]
        public string Description_key { get; set; }
        [XmlAttribute(AttributeName = "title_key")]
        public string Title_key { get; set; }
        [XmlAttribute(AttributeName = "exp_to_level")]
        public string Exp_to_level { get; set; }
        [XmlAttribute(AttributeName = "experience_multiplier")]
        public string Experience_multiplier { get; set; }
        [XmlAttribute(AttributeName = "group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "recipe")]
        public List<RecipeInternal> Recipe { get; set; }
    }

    [XmlRoot(ElementName = "crafting_skill")]
    public class Crafting_skill
    {
        [XmlElement(ElementName = "effect")]
        public List<Effect> Effect { get; set; }
        [XmlElement(ElementName = "recipe")]
        public List<RecipeInternal> Recipe { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
        [XmlAttribute(AttributeName = "description_key")]
        public string Description_key { get; set; }
        [XmlAttribute(AttributeName = "title_key")]
        public string Title_key { get; set; }
        [XmlAttribute(AttributeName = "group")]
        public string Group { get; set; }
        [XmlAttribute(AttributeName = "exp_to_level")]
        public string Exp_to_level { get; set; }
    }

    [XmlRoot(ElementName = "skills")]
    public class Skills
    {
        [XmlElement(ElementName = "player_skill")]
        public List<Player_skill> Player_skill { get; set; }
        [XmlElement(ElementName = "perk")]
        public List<Perk> Perk { get; set; }
        [XmlElement(ElementName = "action_skill")]
        public List<Action_skill> Action_skill { get; set; }
        [XmlElement(ElementName = "crafting_skill")]
        public List<Crafting_skill> Crafting_skill { get; set; }
        [XmlAttribute(AttributeName = "max_level")]
        public string Max_level { get; set; }
        [XmlAttribute(AttributeName = "exp_to_level")]
        public string Exp_to_level { get; set; }
        [XmlAttribute(AttributeName = "experience_multiplier")]
        public string Experience_multiplier { get; set; }
        [XmlAttribute(AttributeName = "skill_point_cost_multiplier")]
        public string Skill_point_cost_multiplier { get; set; }
        [XmlAttribute(AttributeName = "skill_point_cost_per_level")]
        public string Skill_point_cost_per_level { get; set; }
    }

    [XmlRoot(ElementName = "progression")]
    public class Progression
    {
        [XmlElement(ElementName = "player")]
        public Player Player { get; set; }
        [XmlElement(ElementName = "skills")]
        public Skills Skills { get; set; }
    }
}
