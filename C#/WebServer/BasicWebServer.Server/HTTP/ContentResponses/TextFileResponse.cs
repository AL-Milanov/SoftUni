using System.IO;

namespace BasicWebServer.Server.HTTP.ContentResponses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; init; }

        public TextFileResponse(string filename)
            : base(StatusCode.OK)
        {
            FileName = filename;

            Headers.Add(Header.ContentType, ContentType.PlainText);
        }
            
        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                Body = File.ReadAllTextAsync(FileName).Result;

                var fileBytesCount = new FileInfo(FileName).Length;

                Headers.Add(Header.ContentLength, fileBytesCount.ToString());

                Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            }

            return base.ToString();
        }
    }
}
