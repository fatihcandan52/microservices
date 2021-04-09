using Microservices.Contract.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microservices.Contract.Result
{
    public class Result
    {
        [JsonIgnore]
        public StatusCode StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        public static Result Success(StatusCode statusCode)
        {
            return new Result
            {
                StatusCode = statusCode,
                IsSuccess = true
            };
        }

        public static Result Error(StatusCode statusCode)
        {
            return new Result
            {
                StatusCode = statusCode,
                IsSuccess = false
            };
        }
    }
}
