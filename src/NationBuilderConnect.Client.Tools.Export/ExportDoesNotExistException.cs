using System;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportDoesNotExistException : Exception
    {
        public ExportDoesNotExistException(int exportId)
        {
            ExportId = exportId;
        }

        public int ExportId { get; private set; }
    }
}