using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientTemplate.Models
{
    public class Wrap<T>
    {
        private readonly bool _isValid = false;

        public Wrap(T message)
        {
            this.Message = message;
            this._isValid = true;
        }

        public Wrap()
        {
            this._isValid = false;
        }

        public bool IsValid
        {
            get
            {
                return this._isValid;
            }
        }

        public T Message { get; private set; }
    }
}
