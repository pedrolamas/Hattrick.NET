using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hattrick.Service
{
    interface IRequest<T>
    {
        void DoRequest(ConnectionBroker connectionBroker, OnResponse<T> onResponse);
    }
}