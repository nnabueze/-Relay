using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relay.Domain.Interface
{
    public interface IWebcallService
    {
        public Task<string> PostDataCall(string url, string parameter);
    }
}
