using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.Dtos
{
    public class Result
    {
        public HttpStatus Status { get; set; }
        public string Message { get; set; }
    }

    public enum HttpStatus
    {
        Ok,
        Error
    }
}
