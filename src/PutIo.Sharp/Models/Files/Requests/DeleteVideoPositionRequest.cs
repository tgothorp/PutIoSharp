namespace PutIo.Sharp.Models.Files.Requests
{
    public class DeleteVideoPositionRequest
    {
        public DeleteVideoPositionRequest(long fileId)
        {
            FileId = fileId;
        }
        
        public long FileId { get; set; }
    }
}