using System;

namespace Hattrick.Service.Components
{
    public class HattrickException : Exception
    {
        public HattrickException(string Message)
            : base(Message)
        {
        }
    }
}