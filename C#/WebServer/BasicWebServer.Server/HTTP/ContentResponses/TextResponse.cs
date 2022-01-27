using System;

namespace BasicWebServer.Server.HTTP.ContentResponses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content) 
            : base(content, ContentType.PlainText)
        {
        }
    }
}
