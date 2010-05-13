using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class EconomyResponseInfo : BaseResponseInfo
    {
        #region Enumerations - not generated

        #endregion

        #region Constructors
        public EconomyResponseInfo()
        {
            Team = new TeamDetails();
        }
        #endregion

        #region Properties


        [XmlElement]
        public TeamDetails Team { get; set; }

        #endregion

        #region Auxiliary Classes

        public class TeamDetails
        {
            #region Properties

            [XmlElement]
            public GenericNode<int> TeamID { get; set; }
            [XmlElement]
            public GenericNode<string> TeamName { get; set; }
            [XmlElement]
            public GenericNode<int> Cash { get; set; }
            [XmlElement]
            public GenericNode<int> ExpectedCash { get; set; }
            [XmlElement]
            public GenericNode<int> SponsorsPopularity { get; set; }
            [XmlElement]
            public GenericNode<int> SupportersPopularity { get; set; }
            [XmlElement]
            public GenericNode<int> FanClubSize { get; set; }
            [XmlElement]
            public GenericNode<int> IncomeSpectators { get; set; }
            [XmlElement]
            public GenericNode<int> IncomeSponsors { get; set; }
            [XmlElement]
            public GenericNode<int> IncomeFinancial { get; set; }
            [XmlElement]
            public GenericNode<int> IncomeTemporary { get; set; }
            [XmlElement]
            public GenericNode<int> IncomeSum { get; set; }
            [XmlElement]
            public GenericNode<int> CostsArena { get; set; }
            [XmlElement]
            public GenericNode<int> CostsPlayers { get; set; }
            [XmlElement]
            public GenericNode<int> CostsFinancial { get; set; }
            [XmlElement]
            public GenericNode<int> CostsStaff { get; set; }
            [XmlElement]
            public GenericNode<int> CostsTemporary { get; set; }
            [XmlElement]
            public GenericNode<int> CostsYouth { get; set; }
            [XmlElement]
            public GenericNode<int> CostsSum { get; set; }
            [XmlElement]
            public GenericNode<int> ExpectedWeeksTotal { get; set; }
            [XmlElement]
            public GenericNode<int> LastIncomeSpectators { get; set; }
            [XmlElement]
            public GenericNode<int> LastIncomeSponsors { get; set; }
            [XmlElement]
            public GenericNode<int> LastIncomeFinancial { get; set; }
            [XmlElement]
            public GenericNode<int> LastIncomeTemporary { get; set; }
            [XmlElement]
            public GenericNode<int> LastIncomeSum { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsArena { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsPlayers { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsFinancial { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsStaff { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsTemporary { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsYouth { get; set; }
            [XmlElement]
            public GenericNode<int> LastCostsSum { get; set; }
            [XmlElement]
            public GenericNode<int> LastWeeksTotal { get; set; }


            #endregion
        }


        #endregion
    }
}
