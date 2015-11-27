using Microsoft.AspNet.Http;

namespace BockitServer.Services
{
    public class RequestProcessor
	{
		public string Process(HttpContext context)
		{
			return "Hello World";
		}
	}	
}