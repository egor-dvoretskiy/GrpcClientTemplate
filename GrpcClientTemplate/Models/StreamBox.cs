using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientTemplate.Models
{
    public sealed class StreamBox<T1, T2>
    {
        private readonly IClientStreamWriter<T1> _requestStream;
        private readonly IAsyncStreamReader<T2> _responseStream;

        public StreamBox(IClientStreamWriter<T1> requestStream, IAsyncStreamReader<T2> responseStream)
        {
            this._responseStream = responseStream;
            this._requestStream = requestStream;
        }

        public IClientStreamWriter<T1> RequestStream
        {
            get
            {
                return this._requestStream;
            }
        }

        public IAsyncStreamReader<T2> ResponseStream
        {
            get
            {
                return this._responseStream;
            }
        }
    }
}
