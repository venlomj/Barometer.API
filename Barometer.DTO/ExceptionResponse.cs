using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DTO
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
