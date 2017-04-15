using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ValmodSkillParser
{
    public class Quest
    {
        [XmlRoot(ElementName = "action")]
        public class Action
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "objective")]
        public class Objective
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "optional")]
            public string Optional { get; set; }
        }

        [XmlRoot(ElementName = "reward")]
        public class Reward
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "stage")]
            public string Stage { get; set; }
            [XmlAttribute(AttributeName = "optional")]
            public string Optional { get; set; }
        }

        [XmlRoot(ElementName = "quest")]
        public class QuestInternal
        {
            [XmlElement(ElementName = "action")]
            public List<Action> Action { get; set; }
            [XmlElement(ElementName = "objective")]
            public List<Objective> Objective { get; set; }
            [XmlElement(ElementName = "reward")]
            public List<Reward> Reward { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "group_name_key")]
            public string Group_name_key { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "name_key")]
            public string Name_key { get; set; }
            [XmlAttribute(AttributeName = "subtitle")]
            public string Subtitle { get; set; }
            [XmlAttribute(AttributeName = "subtitle_key")]
            public string Subtitle_key { get; set; }
            [XmlAttribute(AttributeName = "description_key")]
            public string Description_key { get; set; }
            [XmlAttribute(AttributeName = "icon")]
            public string Icon { get; set; }
            [XmlAttribute(AttributeName = "category_key")]
            public string Category_key { get; set; }
            [XmlAttribute(AttributeName = "offer_key")]
            public string Offer_key { get; set; }
            [XmlAttribute(AttributeName = "repeatable")]
            public string Repeatable { get; set; }
            [XmlAttribute(AttributeName = "difficulty")]
            public string Difficulty { get; set; }
            [XmlElement(ElementName = "requirement")]
            public List<Requirement> Requirement { get; set; }
            [XmlAttribute(AttributeName = "description")]
            public string Description { get; set; }
            [XmlAttribute(AttributeName = "offer")]
            public string Offer { get; set; }
        }

        [XmlRoot(ElementName = "requirement")]
        public class Requirement
        {
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "requirement")]
            public List<Requirement> RequirementInternal { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "quests")]
        public class Quests
        {
            [XmlElement(ElementName = "quest")]
            public List<QuestInternal> Quest { get; set; }
        }
    }
}
