using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Results
{
    public class Result(bool isSuccess, string errorMessage)
    {
        private readonly bool IsSuccess = isSuccess;
        private readonly string ErrorMessage = errorMessage;

        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; private set; }

        protected Result(bool isSuccess, T value, string errorMessage)
            : base(isSuccess, errorMessage)
        {
            Value = value;
        }
        
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default(T), errorMessage);
        }
    }
}
