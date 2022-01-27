using System;

namespace BasicWebServer.Server.HTTP.ContentResponses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content)
            : base(content, ContentType.Html)
        {
        }
    }
}
