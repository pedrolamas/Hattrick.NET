using Hattrick.Service.BaseClasses;

namespace Hattrick.Service.Requests
{
    public class AllianceDetailsRequestInfo : BaseRequestInfo
    {
        public AllianceDetailsRequestInfo()
        {
            // Set defaults here
            Subset = CharacterEnum.All;
        }


        #region Enumerations
        public enum ActionTypeEnum
        {
            roles,
            members,
            membersSubset
        }
        public enum CharacterEnum
        {
            All = -1, A = 65, B = 66, C = 67, D = 68, E = 69, F = 70, G = 71, H = 72, I = 73, J = 74, K = 75, L = 76, M = 77, N = 78, O = 79, P = 80, Q = 81, R = 82, S = 83, T = 84, U = 85, V = 86, W = 87, X = 88, Y = 89, Z = 90, Other = 0
        }
        #endregion

        #region Properties
        public ActionTypeEnum ActionType { get; set; }
        public int AllianceId { get; set; }
        public int AllianceRoleId { get; set; }
        public CharacterEnum Subset { get; set; }
        #endregion
    }
}