using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using Microsoft.ServiceFabric.Services.Remoting.V2.Messaging;
using Newtonsoft.Json;

namespace Stateless1.MSDocs
{
    class ServiceRemotingRequestJsonMessageBodySerializer : IServiceRemotingRequestMessageBodySerializer
    {
        private JsonSerializer serializer;

        public ServiceRemotingRequestJsonMessageBodySerializer()
        {
            serializer = JsonSerializer.Create(
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
        }

        public IOutgoingMessageBody Serialize(IServiceRemotingRequestMessageBody serviceRemotingRequestMessageBody)
        {
            if (serviceRemotingRequestMessageBody == null)
            {
                return null;
            }

            using (var writeStream = new MemoryStream())
            {
                using (var jsonWriter = new JsonTextWriter(new StreamWriter(writeStream)))
                {
                    serializer.Serialize(jsonWriter, serviceRemotingRequestMessageBody);
                    jsonWriter.Flush();
                    var bytes   = writeStream.ToArray();
                    var segment = new ArraySegment<byte>(bytes);
                    var segments = new List<ArraySegment<byte>>
                    {
                        segment
                    };
                    return new OutgoingMessageBody(segments);
                }
            }
        }

        public IServiceRemotingRequestMessageBody Deserialize(IIncomingMessageBody messageBody)
        {
            using (var sr = new StreamReader(messageBody.GetReceivedBuffer()))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var ob = serializer.Deserialize<JsonBody>(reader);
                    return ob;
                }
            }
        }
    }
}
