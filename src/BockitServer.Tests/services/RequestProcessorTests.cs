using BockitServer.Services;
using Microsoft.AspNet.Http;
using NSubstitute;
using Pancakes.TestUtilities;
using Xunit;

namespace BockitServer.UnitTests
{
    public class RequestProcessorRequests  : BaseUnitTest<RequestProcessor>
    {        
        public class Process : RequestProcessorRequests
        {
            [Fact]
            public void SimpleProcess()
            {
                var writer = this.GetMock<IResponseWriter>();
                var context = this.GetMock<HttpContext>();
                
                this.SystemUnderTest.Process(context);
                
                writer.Received().Write(Arg.Any<BockitResponse>(), Arg.Any<HttpResponse>());
            }
        }
    }
}
