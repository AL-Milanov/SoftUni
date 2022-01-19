namespace BasicWebServer.Server.HTTP.ActionResponses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }
    }
}
