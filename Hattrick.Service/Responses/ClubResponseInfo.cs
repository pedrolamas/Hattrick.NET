using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ClubResponseInfo : BaseResponseInfo
    {
        #region Enumerations - not generated

        #endregion

        #region Constructors
        public ClubResponseInfo()
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
            public SpecialistsDetails Specialists { get; set; }
            [XmlElement]
            public YouthSquadDetails YouthSquad { get; set; }

            #endregion
        }

        public class SpecialistsDetails
        {
            #region Properties

            [XmlElement]
            public GenericNode<int> KeeperTrainers { get; set; }
            [XmlElement]
            public GenericNode<int> AssistantTrainers { get; set; }
            [XmlElement]
            public GenericNode<int> Psychologists { get; set; }
            [XmlElement]
            public GenericNode<int> PressSpokesmen { get; set; }
            [XmlElement]
            public GenericNode<int> Economists { get; set; }
            [XmlElement]
            public GenericNode<int> Physiotherapists { get; set; }
            [XmlElement]
            public GenericNode<int> Doctors { get; set; }


            #endregion
        }

        public class YouthSquadDetails
        {
            #region Properties

            [XmlElement]
            public GenericNode<int> Investment { get; set; }
            [XmlElement]
            public BooleanNode HasPromoted { get; set; }
            [XmlElement]
            public GenericNode<int> YouthLevel { get; set; }


            #endregion
        }


        #endregion
    }
}
