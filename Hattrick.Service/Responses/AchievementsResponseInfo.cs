using System;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class AchievementsResponseInfo : BaseResponseInfo
    {
        #region Enumerations - not generated
        public enum Category
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
            AchievementList = new AchievementListDetails();
        }
        #endregion

        #region Properties

        [XmlElement]
        public AchievementListDetails AchievementList { get; set; }

        #endregion

        #region Auxiliary Classes

        public class AchievementListDetails
        {
            public AchievementListDetails()
            {
                Achievement = new AchievementDetails();
            }

            #region Properties


            [XmlElement]
            public AchievementDetails Achievement { get; set; }

            #endregion
        }

        public class AchievementDetails
        {
            public AchievementDetails()
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
            public Category Category
            {
                get
                {
                    return (AchievementsResponseInfo.Category)Enum.Parse(typeof(AchievementsResponseInfo.Category), CategoryID.ToString());
                }
            }

            #endregion
        }


        #endregion
    }
}
