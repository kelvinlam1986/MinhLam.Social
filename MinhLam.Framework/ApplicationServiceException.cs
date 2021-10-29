using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhLam.Framework
{
    public class ApplicationServiceException : Exception
    {
        public string Code { get; }

        public ApplicationServiceException()
        {
        }

        public ApplicationServiceException(string code)
        {
            Code = code;
        }

        public ApplicationServiceException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public ApplicationServiceException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public ApplicationServiceException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ApplicationServiceException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
