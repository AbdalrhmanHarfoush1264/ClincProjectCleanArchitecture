using System.Net;

namespace ClincProject.Core.BasesCore
{
    public class CusResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Successed { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        //public object meta

        public CusResponse()
        {

        }

        public CusResponse(T data, string message = null)
        {
            Successed = true;
            Data = data;
            Message = message;
        }
        public CusResponse(string message)
        {
            Successed = false;
            Message = message;
        }

        public CusResponse(string message, bool successed)
        {
            Message = message;
            Successed = successed;
        }
    }
}
