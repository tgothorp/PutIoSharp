namespace PutIo.Sharp.Models.Files.Requests
{
    public class ConvertFileToMp4Request
    {
        public ConvertFileToMp4Request(long fileId)
        {
            FileId = fileId;
        }
        
        /// <summary>
        /// The id of the file to be converted
        /// </summary>
        public long FileId { get; set; }
    }
}