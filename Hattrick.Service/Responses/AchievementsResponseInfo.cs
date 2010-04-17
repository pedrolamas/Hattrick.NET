using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class AchievementsResponseInfo : BaseResponseInfo
    {
        #region Enumerations - not generated
        public enum Categories
        {
            Ranking = 1,
            Team = 2,
            Matches = 3,
            Manager = 4,
            SpecialAwards = 5
        }
        #endregion

        #region Constructors
        public AchievementsResponseInfo()
        {
            AchievementList = new List<Achievement>();
        }
        #endregion

        #region Properties

        [XmlArray]
        public List<Achievement> AchievementList { get; set; }

        #endregion

        #region Auxiliary Classes
        public class Achievement
        {
            public Achievement()
            {
            }

            #region Properties

            [XmlElement]
            public GenericNode<int> AchievementTypeID { get; set; }
            [XmlElement]
            public GenericNode<string> AchievementText { get; set; }
            [XmlElement]
            public GenericNode<int> CategoryID { get; set; }
            [XmlElement]
            public DateTimeNode EventDate { get; set; }
            [XmlElement]
            public GenericNode<int> Points { get; set; }
            [XmlElement]
            public GenericNode<string> MultiLevel { get; set; }
            [XmlElement]
            public GenericNode<int> NumberOfEvents { get; set; }

            [XmlIgnore]
            public Categories Category
            {
                get
                {
                    return (AchievementsResponseInfo.Categories)Enum.Parse(typeof(AchievementsResponseInfo.Categories), CategoryID.ToString());
                }
            }

            #endregion
        }


        #endregion
    }
}
