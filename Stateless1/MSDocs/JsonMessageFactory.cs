using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Stateless1.MSDocs
{
    class JsonMessageFactory : IServiceRemotingMessageBodyFactory
    {
        public IServiceRemotingRequestMessageBody CreateRequest(
            string interfaceName, string methodName, int numberOfParameters, object wrappedRequestObject)
        {
            return new JsonBody(wrappedRequestObject);
        }

        public IServiceRemotingResponseMessageBody CreateResponse(
            string interfaceName, string methodName, object wrappedRequestObject)
        {
            return new JsonBody(wrappedRequestObject);
        }
    }
}
