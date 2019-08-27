using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Client;
using Stateless1;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var proxyFactory = new ServiceProxyFactory(
                (c) =>
                {
                    return new FabricTransportServiceRemotingClientFactory(
                        //serializationProvider: new Stateless1.MSDocs.ServiceRemotingJsonSerializationProvider());
                        //serializationProvider: new Stateless1.suchiagicha.ServiceRemotingJsonSerializationProvider());
                        serializationProvider: new Stateless1.washraf.ServiceRemotingJsonSerializationProvider());
                });

            var client = proxyFactory.CreateServiceProxy<IMyService>(new Uri("fabric:/FabricSerializer/Stateless1"));
            //var client = ServiceProxy.Create<IMyService>(new Uri("fabric:/FabricSerializer/Stateless1"));

            var message = await client.GetDataAsync();

            return Ok(message);
        }
    }
}
