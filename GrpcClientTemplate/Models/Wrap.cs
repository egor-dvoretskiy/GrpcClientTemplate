using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientTemplate.Models
{
    public class Wrap<T>
        where T : class
    {
        private readonly bool _isValid = false;
        private readonly string _issueExplanation = string.Empty;

        /// <summary>
        /// Default constructor. It wraps the result with 'isValid = true' cover.
        /// </summary>
        /// <param name="message"></param>
        public Wrap(T message)
        {
            this.Message = message;
            this._isValid = true;

            this._issueExplanation = "No need in explanation.";
        }

        /// <summary>
        /// Constructor for wrapper with invalid input message.
        /// </summary>
        /// <param name="stubBoolean">This is a stub. It is using here only for prevent crossing between 'string' and 'T'. There are no actions under here.</param>
        /// <param name="issueExplanation">Explanation for issue.</param>
        public Wrap(bool stubBoolean = true, string issueExplanation = "No explanation")
        {
            this._isValid = false;
            _ = stubBoolean;

            this._issueExplanation = string.Concat(typeof(T), "\t", issueExplanation);
        }

        /// <summary>
        /// Explanation of issue.
        /// </summary>
        public string IssueExplanation
        {
            get => this._issueExplanation;
        }

        /// <summary>
        /// Determines the validness of input wrapped package.
        /// </summary>
        public bool IsValid
        {
            get => this._isValid;
        }

        /// <summary>
        /// The wrapped message.
        /// </summary>
        public T Message { get; private set; }
    }
}
