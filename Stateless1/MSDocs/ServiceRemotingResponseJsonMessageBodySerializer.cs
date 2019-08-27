﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.ServiceFabric.Services.Remoting.V2;
using Microsoft.ServiceFabric.Services.Remoting.V2.Messaging;
using Newtonsoft.Json;

namespace Stateless1.MSDocs
{
    class ServiceRemotingResponseJsonMessageBodySerializer : IServiceRemotingResponseMessageBodySerializer
    {
        private JsonSerializer serializer;

        public ServiceRemotingResponseJsonMessageBodySerializer()
        {
            serializer = JsonSerializer.Create(
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
        }

        public IOutgoingMessageBody Serialize(IServiceRemotingResponseMessageBody responseMessageBody)
        {
            if (responseMessageBody == null)
            {
                return null;
            }

            using (var writeStream = new MemoryStream())
            {
                using (var jsonWriter = new JsonTextWriter(new StreamWriter(writeStream)))
                {
                    serializer.Serialize(jsonWriter, responseMessageBody);
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

        public IServiceRemotingResponseMessageBody Deserialize(IIncomingMessageBody messageBody)
        {
            using (var sr = new StreamReader(messageBody.GetReceivedBuffer()))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    var obj = serializer.Deserialize<JsonBody>(reader);
                    return obj;
                }
            }
        }
    }
}
