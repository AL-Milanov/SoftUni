using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.ActionResponses;
using BasicWebServer.Server.HTTP.ContentResponses;

namespace BasicWebServer.Server.Controllers
{
    public abstract class Controller
    {
        public Controller(Request request)
        {
            Request = request;
        }

        public Request Request { get; private init; }

        protected Response Text(string text)
        {
            return new TextResponse(text);
        }

        protected Response File(string fileName)
        {
            return new TextFileResponse(fileName);
        }

        protected Response Html(string html, CookieCollection cookies = null)
        {
            var response =  new HtmlResponse(html);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest()
        {
            return new BadRequestResponse();
        }

        protected Response NotFound()
        {
            return new NotFoundResponse();
        }

        protected Response Redirect(string location)
        {
            return new RedirectResponse(location);
        }

        protected Response Unauthorized()
        {
            return new UnauthorizedResponse();
        }
    }
}
