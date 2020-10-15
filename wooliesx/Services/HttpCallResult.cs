using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace wooliesx.Services
{
    public class HttpCallResult<TResponseContent> where TResponseContent : class
    {
        public HttpCallResult()
        {
        }

        public HttpCallResult(bool success, HttpStatusCode httpStatusCode, string errorMessage,
            TResponseContent content, Exception exception = null)
        {
            Success = success;
            HttpStatusCode = httpStatusCode;
            ErrorMessage = errorMessage;
            Content = content;
            Exception = exception;
        }

        public bool Success { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public TResponseContent Content { get; set; }
        public Exception Exception { get; set; }
    }
}
