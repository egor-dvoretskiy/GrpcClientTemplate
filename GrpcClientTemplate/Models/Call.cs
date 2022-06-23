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

        /// <summary>
        /// Constructor for call.
        /// </summary>
        /// <param name="name">Name of the call. Property name.</param>
        /// <param name="streamingCall">Client streaming call.</param>
        public Call(string name, AsyncDuplexStreamingCall<T1, T2> streamingCall)
        {
            this._name = name;
            this.StreamingCall = streamingCall;

            this.StreamBox = new StreamBox<T1, T2>(this.StreamingCall.RequestStream, this.StreamingCall.ResponseStream);
        }

        /// <summary>
        /// Name of the call.
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        /// <summary>
        /// Client streaming call.
        /// </summary>
        public AsyncDuplexStreamingCall<T1, T2> StreamingCall { get; private set; }

        /// <summary>
        /// Contains read/write streams.
        /// </summary>
        public StreamBox<T1, T2> StreamBox { get; private set; }

        /// <summary>
        /// Provides means to cleanup after the call. If the call has already finished normally
        ///     (request stream has been completed and response stream has been fully read),
        ///     doesn't do anything. Otherwise, requests cancellation of the call which should
        ///     terminate all pending async operations associated with the call. As a result,
        ///     all resources being used by the call should be released eventually.
        /// </summary>
        public void Dispose()
        {
            this.StreamingCall?.Dispose();
        }
    }
}
