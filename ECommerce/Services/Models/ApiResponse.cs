using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public ApiResponse(int statusCode, string message, dynamic? model)
        {
            StatusCode = statusCode;
            Message = message;
            Model = model;
        }
        public int StatusCode { get;  set; }
        public string Message { get; set; } = "An Error occured";
        public dynamic? Model { get; set; }
    }
}
