using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Hattrick.Service
{
    public abstract class BaseRequestInfo
    {
    }
    //public abstract class BaseRequestInfo<T> where T : BaseResponseInfo
    //{
    //    protected abstract string RequestUrl();

    //    public T GetResponse()
    //    {
    //    }

    //    public IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
    //    {
    //        HttpWebRequest cRequest = HttpWebRequest.Create(RequestUrl());

    //        cRequest.BeginGetResponse(delegate(IAsyncResult asyncResult)
    //        {
    //            HttpWebResponse cResponse = cRequest.EndGetResponse(asyncResult);

    //            callback(asyncResult);
    //        });
    //    }

    //    public T EndGetResponse(IAsyncResult asyncResult)
    //    {
    //        //return asyncResult
    //    }
    //}
}