using System;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportIsNotCompleteException : Exception
    {
        public ExportIsNotCompleteException(int exportId)
        {
            ExportId = exportId;
        }

        public int ExportId { get; private set; }
    }
}