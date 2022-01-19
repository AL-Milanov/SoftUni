namespace BasicWebServer.Server.HTTP.ActionResponses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
