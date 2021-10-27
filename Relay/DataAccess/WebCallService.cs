using Relay.Domain.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Relay.DataAccess
{
    public class WebCallService : IWebcallService
    {
        public async Task<string> PostDataCall(string url, string json)
        {
            string responseText = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(url);
            httpWebReq.ContentType = "application/json";
            httpWebReq.Accept = "application/json";
            httpWebReq.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(await httpWebReq.GetRequestStreamAsync()))
            {

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            try
            {
                using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebReq.GetResponseAsync())
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        return responseText;
                    }

                    using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        responseText = streamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {

                using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }
            }


            return responseText;
        }
    }
}
