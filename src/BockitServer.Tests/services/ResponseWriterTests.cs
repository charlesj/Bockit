using BockitServer.Services;
using Microsoft.AspNet.Http;
using Pancakes.TestUtilities;
using Xunit;

namespace BockitServer.Tests.Services
{
    public class ResponseWriterTests : BaseUnitTest<ResponseWriter>
	{
		public class Write : ResponseWriterTests
		{
			[Fact]
			public void WritesResponseCorrectly()
			{
				var response = new BockitResponse { HttpCode = 200 };
				var httpResponse = this.GetMock<HttpResponse>();
											
				this.SystemUnderTest.Write(response, httpResponse);
				
				Assert.Equal(200, httpResponse.StatusCode);
				Assert.Equal("application/json", httpResponse.ContentType);
			}
        }
	}
}