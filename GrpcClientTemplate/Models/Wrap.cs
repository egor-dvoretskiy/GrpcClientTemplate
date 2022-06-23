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
        private readonly string _issueExplanation = string.Empty;

        public Wrap(T message)
        {
            this.Message = message;
            this._isValid = true;

            this._issueExplanation = "No need in explanation.";
        }

        public Wrap(string issueExplanation = "No explanation")
        {
            this._isValid = false;

            this._issueExplanation = issueExplanation;
        }

        public string IssueExplanation
        {
            get => this._issueExplanation;
        }

        public bool IsValid
        {
            get => this._isValid;
        }

        public T Message { get; private set; }
    }
}
