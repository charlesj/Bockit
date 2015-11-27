using Microsoft.AspNet.Builder;
using BockitServer.Services;

namespace BockitServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var processor = new RequestProcessor(new ResponseWriter());
            app.Run(async (context) => processor.Process(context) );
        }
    }
}
