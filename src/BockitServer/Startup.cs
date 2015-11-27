using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using BockitServer.Services;

namespace BockitServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var processor = new RequestProcessor();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(processor.Process(context.Request.QueryString.ToString()));
            });
        }
    }
}
