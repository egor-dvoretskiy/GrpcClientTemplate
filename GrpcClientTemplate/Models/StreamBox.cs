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

        /// <summary>
        /// Constructor of StreamBox. Creates instances of read/write streams by DI.
        /// </summary>
        /// <param name="requestStream">Write stream.</param>
        /// <param name="responseStream">Read stream.</param>
        public StreamBox(IClientStreamWriter<T1> requestStream, IAsyncStreamReader<T2> responseStream)
        {
            this._responseStream = responseStream;
            this._requestStream = requestStream;
        }

        /// <summary>
        /// Write/Request stream. 
        /// </summary>
        public IClientStreamWriter<T1> RequestStream
        {
            get
            {
                return this._requestStream;
            }
        }

        /// <summary>
        /// Read/Response stream.
        /// </summary>
        public IAsyncStreamReader<T2> ResponseStream
        {
            get
            {
                return this._responseStream;
            }
        }
    }
}
