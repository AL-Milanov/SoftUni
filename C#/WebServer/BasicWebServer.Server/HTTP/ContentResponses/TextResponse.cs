using System;

namespace BasicWebServer.Server.HTTP.ContentResponses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content,
            Action<Request, Response> preRenderedAction = null) 
            : base(content, ContentType.PlainText, preRenderedAction)
        {
        }
    }
}
