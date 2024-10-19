using System.Net;

namespace ClincProject.Core.BasesCore
{
    public class CusResponseHandler
    {
        public CusResponseHandler()
        {

        }

        public CusResponse<T> Success<T>(T entity)
        {
            return new CusResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Successed = true,
                Data = entity,
                Message = "Successfully."
            };
        }

        public CusResponse<T> BadRequest<T>(string? message = null)
        {
            return new CusResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Successed = false,
                Message = message == null ? "Bad Request." : message
            };
        }

        public CusResponse<T> NotFound<T>(string? message = null)
        {
            return new CusResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Successed = true,
                Message = message == null ? "Not Found." : message
            };
        }

        public CusResponse<T> ServerError<T>(string? message = null)
        {
            return new CusResponse<T>()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Successed = false,
                Message = message == null ? "Internal Server Error." : message,
                Data = default(T)
            };
        }
    }
}
