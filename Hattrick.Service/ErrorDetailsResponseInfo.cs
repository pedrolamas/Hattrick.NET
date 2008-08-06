using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ErrorDetailsResponseInfo : BaseResponseInfo
    {
        private GenericNode<string> _error;
        private GenericNode<int> _errorCode;
        private GenericNode<Guid> _errorGuid;

        #region Properties

        [XmlElement]
        public GenericNode<string> Error
        {
            get { return _error; }
            set { _error = value; }
        }

        [XmlElement]
        public GenericNode<int> ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        [XmlElement]
        public GenericNode<Guid> ErrorGuid
        {
            get { return _errorGuid; }
            set { _errorGuid = value; }
        }

        #endregion
    }
}