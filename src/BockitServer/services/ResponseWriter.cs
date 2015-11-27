using Microsoft.AspNet.Http;

namespace BockitServer.Services
{
    public interface IResponseWriter
    {
        void Write(BockitResponse response, HttpResponse httpResponse);
    }
    
	public class ResponseWriter : IResponseWriter
	{
        public async void Write(BockitResponse response, HttpResponse outResponse)
        {
            outResponse.StatusCode = response.HttpCode;
            outResponse.ContentType = "application/json";
			if(!string.IsNullOrEmpty(response.Body))
            	await outResponse.WriteAsync(response.Body);
        }
    }
}