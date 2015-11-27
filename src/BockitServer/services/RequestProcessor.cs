using Microsoft.AspNet.Http;

namespace BockitServer.Services
{
    public class RequestProcessor
	{
		private readonly IResponseWriter writer;
		public RequestProcessor(IResponseWriter writer)
		{
			this.writer = writer;
		}
		
		public void Process(HttpContext context)
		{
			this.writer.Write(BockitResponse.Ok(), context.Response);
		}
	}
}