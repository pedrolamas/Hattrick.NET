using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hattrick.Service
{
    public class AlliancesRequestInfo : BaseRequestInfo
    {
        public AlliancesRequestInfo()
        {
            // Set defaults here
            SearchType = SearchTypeEnum.NameBeginsWith;
        }

        #region Enumerations
        public enum SearchTypeEnum
        {
            NameBeginsWith = 1,
            AbbreviationIncludes = 2,
            DescriptionIncludes = 3,
            SearchForId = 4
        }
        #endregion

        #region Properties
        public int SearchLanguageID { get; set; }
        public string SearchFor { get; set; }
        public SearchTypeEnum SearchType { get; set; }
        public int PageIndex { get; set; }
        #endregion
    }
}