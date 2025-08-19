using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ResultType Type { get; set; }

        public static Result SuccessResult(string message = "işlem başarılı")
        {
            return new Result
            {
                Success = true,
                Message = message,
                Type = ResultType.Success
            };
        }


        public static Result WarningResult(string message)
        {
            return new Result
            {
                Success = false,
                Message = message,
                Type = ResultType.Warning
            };
        }

        public static Result FailureResult(string message)
        {
            return new Result
            {
                Success = false,
                Message = message,
                Type = ResultType.Failure
            };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
        public static Result<T> SuccessResult(T data, string message = "işlem başarılı")
        {
            return new Result<T>
            {
                Success = true,
                Message = message,
                Type = ResultType.Success,
                Data = data
            };
        }

        public static Result<T> WarningResult(string message)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Type = ResultType.Warning,
                Data = default  // bir türün varsayılan default değerini verir. int = 0, bool = false, string = null, guid = Guid.Empty
            };
        }

        public static Result<T> FailureResult(string message)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Type = ResultType.Failure,
                Data = default
            };
        }
    }
}