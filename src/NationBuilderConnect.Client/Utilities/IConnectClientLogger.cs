using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderConnect.Client.Utilities
{
    public interface IConnectClientLogger
    {
        void Trace(string message);
    }
}
