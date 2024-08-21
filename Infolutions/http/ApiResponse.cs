using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infolutions.http
{
    public class ApiResponse
    {
        public object? Data { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
    }
}
