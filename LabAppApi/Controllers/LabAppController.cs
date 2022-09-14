using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace LabAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabAppController : ControllerBase
    {
        public LabAppController()
        {

        }
        
        [HttpGet]
        [Route("X")]
        public Task X()
        {
            StreamWriter streamWriter;
            PushStreamContent pushStreamContent;
            Func<Stream, HttpContent, TransportContext, Task> onStreamAvailable;

            onStreamAvailable = (stream, httpContent, transportContext) =>
                Task.Run(async () =>
                {
                    using (streamWriter = new StreamWriter(stream))
                    {
                        for (ushort i = 0; i < ushort.MaxValue; i++)
                        {
                            await Task.Delay(1000);
                            await streamWriter.WriteLineAsync($"test{i}");
                            await HttpContext.Response.WriteAsync($"test{i}");
                            await HttpContext.Response.Body.FlushAsync();
                        }
                    }
                });
            
            pushStreamContent = new(onStreamAvailable, new MediaTypeHeaderValue("text/event-stream"));
            
            return pushStreamContent.CopyToAsync(HttpContext.Response.Body);
        }

        [HttpGet]
        [Route("Y")]
        public async IAsyncEnumerable<string> Y()
        {
            HttpClient httpClient;
            Stream stream;
            StreamReader streamReader;
            
            httpClient = new HttpClient();
            stream = await httpClient.GetStreamAsync("https://localhost:7085/api/labapp/x");
            streamReader = new StreamReader(stream);
            
            while (streamReader != null && !streamReader.EndOfStream)
            {
                yield return streamReader.ReadLine()!;
            }
        }
    }
}
