using Microservices.Contract.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microservices.Contract.Result
{
    public class DataResult<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public StatusCode StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        // Static Factory Metods
        public static DataResult<T> Success(T data, StatusCode statusCode)
        {
            return new DataResult<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true
            };
        }

        //public static DataResult<T> Success(StatusCode statusCode)
        //{
        //    return new DataResult<T>
        //    {
        //        Data = default(T),
        //        StatusCode = statusCode,
        //        IsSuccess = true
        //    };
        //}

        public static DataResult<T> Error(List<string> errors, StatusCode statusCode)
        {
            return new DataResult<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccess = false
            };
        }

        public static DataResult<T> Error(string error, StatusCode statusCode)
        {
            return new DataResult<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode,
                IsSuccess = false
            };
        }
    }
}
