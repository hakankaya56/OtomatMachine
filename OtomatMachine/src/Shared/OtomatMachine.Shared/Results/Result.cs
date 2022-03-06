using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Shared.Results
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Data = data, IsSuccess = true };
        }

        public static Result<T> Success(int statusCode)
        {
            return new Result<T> { Data = default(T), IsSuccess = true };
        }
        public static Result<T> Fail()
        {
            return new Result<T> { IsSuccess = false };
        }
        public static Result<T> Fail(List<string> errors)
        {
            return new Result<T> { Errors = errors,  IsSuccess = false };
        }
        public static Result<T> Fail(string error)
        {
            return new Result<T> { Errors = new List<string> { error }, IsSuccess = false };
        }
    }
}
