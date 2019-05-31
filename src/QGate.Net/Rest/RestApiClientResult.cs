﻿using System.Net.Http;

namespace QGate.Net.Rest
{
    public class RestApiClientResult<TResult>
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public TResult Data { get; set; }
    }
}
