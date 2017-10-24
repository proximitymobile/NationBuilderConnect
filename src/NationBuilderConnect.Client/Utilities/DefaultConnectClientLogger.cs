using System.Diagnostics;

namespace NationBuilderConnect.Client.Utilities
{
    internal class DefaultConnectClientLogger : IConnectClientLogger
    {
        public void Trace(string message)
        {
            // Do not log anything by default
        }
    }
}