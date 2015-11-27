using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BockitServer.Services;
using Microsoft.AspNet.Http;
using Xunit;

namespace BockitServer.UnitTests
{
    public class RequestProcessorRequests
    {
        public class Process : RequestProcessorRequests
        {
            [Fact]
            public void Echos()
            {
                var request = "wokka wokka";
                var processor = new RequestProcessor();
                Assert.Equal(request, processor.Process(request));
            }
        }
    }
}
