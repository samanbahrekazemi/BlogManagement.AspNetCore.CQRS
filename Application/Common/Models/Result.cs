namespace Application.Common.Models
{

    public class Result
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

        public static Result Success()
        {
            return new Result { Succeeded = true };
        }

        public static Result Failure(string errorMessage)
        {
            return new Result { Succeeded = false, ErrorMessage = errorMessage };
        }
    }

    public class Result<T> : Result
    {

        public Result()
        {
        }


        public T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        public static new Result<T> Failure(string errorMessage)
        {
            return new Result<T> { Succeeded = false, ErrorMessage = errorMessage };
        }
    }

}
