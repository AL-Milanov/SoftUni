using System;

namespace BasicWebServer.Server.HTTP.ContentResponses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content,
            Action<Request, Response> preRenderedAction = null)
            : base(content, ContentType.Html, preRenderedAction)
        {
        }
    }
}
