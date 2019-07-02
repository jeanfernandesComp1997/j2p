using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace j2p.Domain.Extensions
{
    public class ExceptionResponse
    {
        public string ExceptionJsonResponse(string exception)
        {
            exception = JsonConvert.SerializeObject(exception);
            return exception;
        }
    }
}
