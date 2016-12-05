using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Errors
{
    /// <summary>
    /// Enum for HTTP Errors
    /// </summary>
    public enum HTTPErrors
    {
        BAD_REQUEST = 400,
        UNAUTHORIZED,
        PAYMENT_REQUIRED,
        FORBIDDEN,
        NOT_FOUND,
        METHOD_NOT_ALLOWED,
        NOT_ACCEPTABLE,
        PROXY_AUTHENTICATION_REQUIRED,
        REQUEST_TIMEOUT,
        CONFLICT,
        GONE,
        LENGTH_REQUIRED,
        PRECONDITION_FAILED,
        REQUEST_ENTITY_TOO_LARGE,
        REQUEST_URI_TOO_LARGE,
        UNSUPPORTED_MEDIA_TYPE,
        RANGE_NOT_SATISFIABLE,
        EXPECTATION_FAILED
    }
}
