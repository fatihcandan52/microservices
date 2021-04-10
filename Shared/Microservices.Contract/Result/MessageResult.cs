using Microservices.Contract.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microservices.Contract.Result
{
    public class MessageResult
    {
        [JsonIgnore]
        public StatusCode StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        public static MessageResult Success(StatusCode statusCode)
        {
            return new MessageResult
            {
                StatusCode = statusCode,
                IsSuccess = true
            };
        }

        public static MessageResult Error(List<string> errors, StatusCode statusCode)
        {
            return new MessageResult
            {
                StatusCode = statusCode,
                Errors = errors,
                IsSuccess = true
            };
        }

        public static MessageResult Error(string error, StatusCode statusCode)
        {
            return new MessageResult
            {
                StatusCode = statusCode,
                Errors = new List<string> { error },
                IsSuccess = false
            };
        }
    }
}
