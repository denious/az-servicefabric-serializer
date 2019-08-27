using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Stateless1.washraf;

namespace Stateless1
{
    public interface IMyService : IService
    {
        Task<CartHeader> GetDataAsync();
    }

    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Stateless1 : StatelessService, IMyService
    {
        public Stateless1(StatelessServiceContext context)
            : base(context)
        {
        }

        public async Task<CartHeader> GetDataAsync()
        {
            using (var ctx = new CartContext())
            {
                await ctx.Database.EnsureCreatedAsync();

                var cart = await ctx.CartHeader
                                    .AsNoTracking()
                                    .Where(o => o.CartID == 36)
                                    .Include(o => o.CartDetail)
                                    .FirstAsync();

                return cart;
            }
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(
                    (c) => new FabricTransportServiceRemotingListener(
                        c,
                        this,
                        null,
                        new ServiceRemotingJsonSerializationProvider()))
            };
        }
    }
}
