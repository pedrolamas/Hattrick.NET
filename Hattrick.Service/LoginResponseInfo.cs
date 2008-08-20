using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class LoginResponseInfo : BaseResponseInfo
    {
        #region Properties

        public GenericNode<int> LoginResult { get; set; }

        public BooleanNode IsAuthenticated { get; set; }

        #endregion
    }
}