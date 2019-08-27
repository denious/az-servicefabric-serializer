using System;
using System.Collections.Generic;
using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Stateless1.MSDocs
{
    public class ServiceRemotingJsonSerializationProvider : IServiceRemotingMessageSerializationProvider
    {
        public IServiceRemotingMessageBodyFactory CreateMessageBodyFactory()
        {
            return new JsonMessageFactory();
        }

        public IServiceRemotingRequestMessageBodySerializer CreateRequestMessageSerializer(
            Type serviceInterfaceType, IEnumerable<Type> requestWrappedType, IEnumerable<Type> requestBodyTypes = null)
        {
            return new ServiceRemotingRequestJsonMessageBodySerializer();
        }

        public IServiceRemotingResponseMessageBodySerializer CreateResponseMessageSerializer(
            Type              serviceInterfaceType, IEnumerable<Type> responseWrappedType,
            IEnumerable<Type> responseBodyTypes = null)
        {
            return new ServiceRemotingResponseJsonMessageBodySerializer();
        }
    }
}
