using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class BaseResponseInfo
    {
        private GenericNode<string> _filename;
        private GenericNode<string> _version;
        private GenericNode<int> _userId;
        private DateTimeNode _fetchedDate;

        #region Properties

        [XmlElement]
        public GenericNode<string> Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        [XmlElement]
        public GenericNode<string> Version
        {
            get { return _version; }
            set { _version = value; }
        }

        [XmlElement("UserID")]
        public GenericNode<int> UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [XmlElement]
        public DateTimeNode FetchedDate
        {
            get { return _fetchedDate; }
            set { _fetchedDate = value; }
        }

        #endregion
    }

}