using BockitServer.Services;
using Microsoft.AspNet.Http;
using NSubstitute;
using Xunit;

namespace BockitServer.Tests.Services
{
    public class ResponseWriterTests
	{
		public class Write : ResponseWriterTests
		{
			[Fact]
			public void WritesResponseCorrectly()
			{
				var response = new BockitResponse { HttpCode = 200 };
				var httpResponse = Substitute.For<HttpResponse>();
				
				var systemUnderTest = new ResponseWriter();
				
				systemUnderTest.Write(response, httpResponse);
				
				Assert.Equal(200, httpResponse.StatusCode);
				Assert.Equal("application/json", httpResponse.ContentType);
			}
        }
	}
}