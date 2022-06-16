using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGrpcTemplate
{
    public abstract class AbstractCallManager<T> : IDisposable 
        where T : class
    {
        public abstract void Dispose();
        protected abstract void InitializeCalls(T client);
    }
}
