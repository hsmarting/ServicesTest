using System.Net;
using System.Net.NetworkInformation;

namespace ServiceTest.Entities
{
    public class Response<T>
    {
        public bool isSuccess { get; set; }
        public HttpStatusCode statusCode { get; set; } = HttpStatusCode.OK;
        public string message { get; set; }
        public T data { get; set; }
        public int row { get; set; } = 0;
    }


    public static class ResponseState<T>
    {
        public static Response<T> NotFound(string message)
        {
            return new Response<T> 
            {
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.NotFound
            };
        }

        public static Response<T> NotFound(T inputData, string message) 
        {
            return new Response<T> 
            {
                data = inputData,
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.NotFound
            };
        }

        public static Response<T> InternalServerError(string message) 
        {
            return new Response<T>
            {
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.InternalServerError
            };
        }

        public static Response<T> InternalServerError(T inputData, string message) 
        {
            return new Response<T> 
            {
                data = inputData,
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.InternalServerError
            };
        }

        public static Response<T> BadRequest(string message) 
        {
            return new Response<T> 
            {
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.BadRequest
            };
        }

        public static Response<T> BadRequest(T inputData, string message) 
        {
            return new Response<T>
            {
                data = inputData,
                isSuccess = false,
                message = message,
                statusCode = HttpStatusCode.BadRequest,
            };
        }

        public static Response<T> Ok(string message) 
        {
            return new Response<T>
            {
                isSuccess = true,
                message = message,
                statusCode = HttpStatusCode.OK
            };
        }

        public static Response<T> Ok(T inputData, string message, int rowCount = 0)
        {
            return new Response<T> 
            {
                data = inputData,
                isSuccess = true,
                message = String.IsNullOrEmpty(message) ? "Success" : message
            };
        }        

    }



}
