using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace wooliesx.Services
{
    public class HttpCallResultBuilder<TResponse> where TResponse : class
    {
        private string _errorResponseMessage;
        private Exception _exception;
        private TResponse _response;
        private HttpStatusCode _statusCode;
        private bool _success;

        public HttpCallResultBuilder<TResponse> WithResponse(TResponse response)
        {
            _response = response;
            return this;
        }

        public HttpCallResultBuilder<TResponse> WithHttpResponseStatusCode(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public HttpCallResultBuilder<TResponse> WithErrorResponseMessage(string errorResponseMessage)
        {
            _errorResponseMessage = errorResponseMessage;
            return this;
        }

        public HttpCallResultBuilder<TResponse> WithException(Exception exception)
        {
            _exception = exception;
            return this;
        }

        public HttpCallResultBuilder<TResponse> WithSuccessIndicator(bool success)
        {
            _success = success;
            return this;
        }

        public HttpCallResult<TResponse> Build()
        {
            return new HttpCallResult<TResponse>(_success, _statusCode, _errorResponseMessage, _response, _exception);
        }

        public static HttpCallResultBuilder<TResponse> New()
        {
            return new HttpCallResultBuilder<TResponse>();
        }
    }
}
