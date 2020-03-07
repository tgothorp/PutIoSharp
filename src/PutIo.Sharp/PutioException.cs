using System;
using PutIo.Sharp.Models.Exceptions;

namespace PutIo.Sharp
{
    public class PutioException : Exception
    {
        public PutioError Error { get; }

        public PutioException(PutioError error) : base(error.Message)
        {
            Error = error;
        }

        public PutioException(Exception innerException) : base("Encountered an unhandled exception when calling the Put.IO api, see the inner exception for more details", innerException)
        {
        }
    }
}