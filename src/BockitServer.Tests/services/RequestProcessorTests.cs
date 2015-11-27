using BockitServer.Services;
using Microsoft.AspNet.Http;
using Ninject;
using Ninject.MockingKernel.NSubstitute;
using NSubstitute;
using Xunit;

namespace BockitServer.UnitTests
{
    public class RequestProcessorRequests : BaseUnitTest<RequestProcessor>
    {
        public class Process : RequestProcessorRequests
        {
            [Fact]
            public void Echos()
            {
                var context = Substitute.For<HttpContext>();
                var response = this.SystemUnderTest.Process(context);
                Assert.Equal("Hello World", response);
            }
        }
    }
    
    public class BaseUnitTest<TSystemUnderTest>
    {
        public BaseUnitTest()
        {
            var kernel = new NSubstituteMockingKernel();
            kernel.Bind<TSystemUnderTest>().To<TSystemUnderTest>();
            this.SystemUnderTest = kernel.Get<TSystemUnderTest>();
        }
        
        public TSystemUnderTest SystemUnderTest {get; private set;}
    }
}
