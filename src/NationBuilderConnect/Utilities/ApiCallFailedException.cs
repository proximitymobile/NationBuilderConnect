using System;
using NationBuilderConnect.Resources;

namespace NationBuilderConnect.Utilities
{
    public class ApiCallFailedException : Exception
    {
        public ApiCallFailedException(ApiResponse response) : base(response.Error?.Message ?? $"API Call failed ({response.HttpStatusCode})")
        {
            Response = response;
        }

        public ApiResponse Response { get; private set; }
    }
}