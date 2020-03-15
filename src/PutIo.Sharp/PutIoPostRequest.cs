using System.Net.Http;

namespace PutIo.Sharp
{
    public abstract class PutIoPostRequest
    {
        internal abstract HttpContent GenerateRequestBody();
    }
}