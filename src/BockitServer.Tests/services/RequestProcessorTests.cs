using BockitServer.Services;
using Microsoft.AspNet.Http;
using NSubstitute;
using Xunit;

namespace BockitServer.UnitTests
{
    public class RequestProcessorRequests // : BaseUnitTest<RequestProcessor>
    {        
        public class Process : RequestProcessorRequests
        {
            [Fact]
            public void SimpleProcess()
            {
                var writer = Substitute.For<IResponseWriter>();
                var context = Substitute.For<HttpContext>();
                
                var systemUnderTest = new RequestProcessor(writer);
                systemUnderTest.Process(context);
                writer.Received().Write(Arg.Any<BockitResponse>(), Arg.Any<HttpResponse>());
            }
        }
    }
}
