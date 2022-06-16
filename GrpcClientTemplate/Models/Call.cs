using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientTemplate.Models
{
    public sealed class Call<T1, T2>
    {
        private readonly string _name;

        public Call(string name, AsyncDuplexStreamingCall<T1, T2> streamingCall)
        {
            this._name = name;
            this.StreamingCall = streamingCall;

            this.StreamBox = new StreamBox<T1, T2>(this.StreamingCall.RequestStream, this.StreamingCall.ResponseStream);
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public AsyncDuplexStreamingCall<T1, T2> StreamingCall { get; private set; }

        public StreamBox<T1, T2> StreamBox { get; private set; }

        public void Dispose()
        {
            this.StreamingCall?.Dispose();
        }
    }
}
