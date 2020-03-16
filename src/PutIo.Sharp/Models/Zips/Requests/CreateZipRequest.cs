using System.Collections.Generic;
using System.Net.Http;

namespace PutIo.Sharp.Models.Zips.Requests
{
    public class CreateZipRequest : PutIoPostRequest
    {
        public CreateZipRequest(params long[] fileIds)
        {
            FileIds = fileIds;
        }

        public CreateZipRequest(IEnumerable<long> fileIds)
        {
            FileIds = fileIds;
        }
        
        public IEnumerable<long> FileIds { get; set; }
        
        internal override HttpContent GenerateRequestBody()
        {
            return new MultipartFormDataContent {{new StringContent(string.Join(",", FileIds)), "file_ids"}};
        }
    }
}