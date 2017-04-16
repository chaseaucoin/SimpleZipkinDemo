using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Middlewares;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Service2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseZipkin(new ZipkinConfig
            {
                Domain = ctx => new Uri("http://Service2"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SampleRate = 1
            });

            app.UseWebApi(config);

            
        }
    }
}
