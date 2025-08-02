using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.ResultPattern
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public static Result<T> SuccessResult(T Data)
        {
            return new Result<T> { IsSuccess = true, Message =  "Operation is success", Data = Data };
        }
        public static Result<T> SuccessResult(T Data, string Message)
        {
            return new Result<T> { IsSuccess = true, Message = string.IsNullOrEmpty(Message) ? "Operation is success" : Message, Data = Data };
        }
        public static Result<T> FailedResult(string Message, List<string> Errors)
        {
            return new Result<T> { IsSuccess = false, Message = string.IsNullOrEmpty(Message) ? "Operation is failed" : Message, Errors = Errors };
        }
        public static Result<T> FailedResult(string Message, string Errors)
        {
            return new Result<T> { IsSuccess = false, Message = string.IsNullOrEmpty(Message) ? "Operation is failed" : Message, Errors = new List<string>() { Errors } };
        }
    }
    public class VoidResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public static VoidResult VoidSuccessResult()
        {
            return new VoidResult { IsSuccess = true, Message = "Operation is success" };
        }
        public static VoidResult VoidSuccessResult(string message)
        {
            return new VoidResult { IsSuccess = true, Message = message };
        }
        public static VoidResult VoidFailedResult(string message, List<string> errors)
        {
            return new VoidResult { IsSuccess = false, Message = message, Errors = errors };
        }
        public static VoidResult VoidFailedResult(string message )
        {
            return new VoidResult { IsSuccess = false, Message = message };
        }
        public static VoidResult VoidFailedResult(List<string> errors)
        {
            return new VoidResult { IsSuccess = false, Message = "Operation is failed", Errors = errors };
        }
        public static VoidResult VoidFailedResult(Exception exception)
        {
            List<string> errors = new List<string>();
            if (exception != null)
            {
                if (!string.IsNullOrEmpty(exception.Message))
                    errors.Add(exception.Message);
                if (exception.InnerException!=null && !string.IsNullOrEmpty(exception.InnerException.Message))
                    errors.Add(exception.InnerException.Message);
                if (exception.InnerException != null && !string.IsNullOrEmpty(exception.InnerException.StackTrace))
                    errors.Add(exception.InnerException.StackTrace);
                return new VoidResult { IsSuccess = false, Message = "Operation is failed", Errors = errors };
            }
            else
            {
                errors.Add("an Unexpected Error Has Occurd");  
                return new VoidResult { IsSuccess = false, Message = "Operation is failed", Errors = errors };
            }
        }
    }
}
