using Relay.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relay.Domain.Interface
{
    public interface ITemple
    {
        public Task<string> SendNotification(TempleModel request);
    }
}
