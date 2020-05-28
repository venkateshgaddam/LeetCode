using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class Response
    {
        public Response() { }

        public Response(HttpStatusCode code, string message, dynamic data)
        {
            this.statusCode = code;
            this.message = message;
            this.data = data;
        }
        public string message { get; set; }

        public HttpStatusCode statusCode { get; set; }

        public object data { get; set; }

    }
}
