using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
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