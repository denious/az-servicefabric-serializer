using System;
using Microsoft.ServiceFabric.Services.Remoting.V2;

namespace Stateless1.MSDocs
{
    class JsonBody : WrappedMessage, IServiceRemotingRequestMessageBody, IServiceRemotingResponseMessageBody
    {
        public JsonBody(object wrapped)
        {
            this.Value = wrapped;
        }

        public void SetParameter(int position, string parameName, object parameter)
        {
            //Not Needed if you are using WrappedMessage
            throw new NotImplementedException();
        }

        public object GetParameter(int position, string parameName, Type paramType)
        {
            //Not Needed if you are using WrappedMessage
            throw new NotImplementedException();
        }

        public void Set(object response)
        {
            //Not Needed if you are using WrappedMessage
            throw new NotImplementedException();
        }

        public object Get(Type paramType)
        {
            //Not Needed if you are using WrappedMessage
            throw new NotImplementedException();
        }
    }
}
