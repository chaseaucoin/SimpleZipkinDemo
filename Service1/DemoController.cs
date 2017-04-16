using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Service1
{
    public class DemoController : ApiController
    {
        // GET api/demo 
        public async Task<string> Get()
        {
            var context = Request.GetOwinContext();
            var config = new ZipkinConfig // you can use Dependency Injection to get the same config across your app.
            {
                Domain = ctx => new Uri("http://Service1"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SampleRate = 1
            };

            var zipkinClient = new ZipkinClient(config, context);
            var url = "http://localhost:8081";
            var requestUri = "/api/demo";

            using (var client = new HttpClient((new ZipkinMessageHandler(zipkinClient))))
            {
                client.BaseAddress = new Uri(url);

                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }

            return "Helo World";
        }

        // GET api/demo/5 
        public string Get(int id)
        {
            return "Hello, World!";
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }
    }
}
