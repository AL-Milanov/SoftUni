﻿namespace BasicWebServer.Server.HTTP.ActionResponses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
