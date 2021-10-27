using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Relay.Domain.Interface;
using Relay.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Relay.DataAccess
{
    public class Temple : ITemple
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IWebcallService _webcallService;

        private string templeNotificationUrl = "https://www.yobe.evas.ng/credit/wpwallet";
        private string templeNotificationUrl2 = "https://www.yobe.evas.ng/credit/cbs";

        public Temple(IHostingEnvironment hostingEnvironment, IWebcallService webcallService = null)
        {
            _hostingEnvironment = hostingEnvironment;

            _webcallService = webcallService;
        }


        public async Task<string> SendNotification(TempleModel request)
        {
            var json = JsonConvert.SerializeObject(request);

            log2(json);

            var response = await _webcallService.PostDataCall(templeNotificationUrl2, json);

            log2(response);

            return response;
        }

        public void log2(string obj)
        {
            string projectRootPath = _hostingEnvironment.ContentRootPath;

            string sPathName = projectRootPath + "/temple.txt";


            try
            {
                using (StreamWriter w = new StreamWriter(sPathName, true))
                {
                    w.WriteLine(Environment.NewLine + "New Log Entry: ");
                    w.WriteLine(DateTime.Now.ToString());
                    w.WriteLine(obj);
                    w.WriteLine("__________________________");
                    w.WriteLine(" ");
                    w.Flush();
                }
            }
            catch (Exception)
            {
                //LogErr(ipath, ex.Message, CStr(myErr.Source))
            }
        }
    }
}
