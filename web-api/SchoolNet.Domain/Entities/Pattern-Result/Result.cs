using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Domain.Entities.Pattern_Repository
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Error { get;}
        public bool IsFailure => !IsSuccess;
        private Result(bool isSucces,string? error)
        {
            IsSuccess = isSucces;
            Error = error;
        }
        public static Result Succes() => new Result(true, string.Empty);
        public static Result Failure(string error) => new Result(false, error);
    }
    public class ResultGeneric<T>
    {
        public T? Value { get; }
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public bool IsFailure => !IsSuccess;

        private ResultGeneric(T? value,bool isSuccess,string? error)
        {
            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }
        public static ResultGeneric<T>Success(T value) => new ResultGeneric<T>(value,true,string.Empty);
        public static ResultGeneric<T> Failure(string error) => new ResultGeneric<T>(default, false, error);
    }
}
