using System;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Files.Requests;
using PutIo.Sharp.Models.Files.Response;

namespace PutIo.Sharp.Clients
{
    public class PutIoFileClient
    {
        private readonly PutioApiClient _apiClient;

        public PutIoFileClient(PutioApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// List files and their properties
        /// </summary>
        public async Task<ListFilesResponse> ListFiles(ListFilesRequest request)
        {
            return await _apiClient.ExecuteGetAsync<ListFilesResponse>($"files/list", request);
        }

        /// <summary>
        /// Fetch remaining files by cursor
        /// </summary>
        public async Task<ListFilesContinueResponse> ListFilesContinue(ListFilesContinueRequest request)
        {
            return await _apiClient.ExecutePostAsync<ListFilesContinueResponse>($"files/list/continue", request);
        }

        /// <summary>
        /// Search the users files and the files of user's friends
        /// </summary>
        public async Task<SearchFilesResponse> SearchFiles(SearchFilesRequest request)
        {
            return await _apiClient.ExecuteGetAsync<SearchFilesResponse>($"files/search", request);
        }

        /// <summary>
        /// Retrieve the remaining search results via cursor 
        /// </summary>
        public async Task<SearchFilesContinueResponse> SearchFilesContinue(SearchFilesContinueRequest request)
        {
            return await _apiClient.ExecutePostAsync<SearchFilesContinueResponse>("files/search/continue", request);
        }

        /// <summary>
        /// Creates a folder
        /// </summary>
        public async Task<CreateFolderResponse> CreateFolder(CreateFolderRequest request)
        {
            return await _apiClient.ExecutePostAsync<CreateFolderResponse>("files/create-folder", request);
        }

        /// <summary>
        /// Rename a file or folder 
        /// </summary>
        public async Task RenameFile(RenameFileRequest request)
        {
            await _apiClient.ExecutePostAsync("files/rename", request);
        }

        /// <summary>
        /// Move files
        /// </summary>
        public async Task MoveFiles(MoveFilesRequest request)
        {
            await _apiClient.ExecutePostAsync("files/move", request);
        }

        /// <summary>
        /// Converts a file to MP4
        /// </summary>
        public async Task ConvertFileToMp4(ConvertFileToMp4Request request)
        {
            await _apiClient.ExecutePostAsync($"files/{request.FileId}/mp4");
        }

        /// <summary>
        /// Gets the MP4 conversion status for a file
        /// </summary>
        public async Task<Mp4ConversionStatusResponse> Mp4ConversionStatus(Mp4ConversionStatusRequest request)
        {
            return await _apiClient.ExecuteGetAsync<Mp4ConversionStatusResponse>($"files/{request.FileId}/mp4");
        }

        /// <summary>
        /// Get available subtitles for a file for user's preferred language
        /// </summary>
        public async Task<SubtitlesResponse> ListSubtitles(SubtitlesRequest request)
        {
            return await _apiClient.ExecuteGetAsync<SubtitlesResponse>($"files/{request.FileId}/subtitles");
        }

        /// <summary>
        /// Download a subtitle file
        /// </summary>
        public async Task<string> DownloadSubtitles(DownloadSubtitlesRequest request)
        {
            return await _apiClient.ExecuteGetAsync<string>($"files/{request.FileId}/subtitles/{request.Key}", request);
        }

        /// <summary>
        /// Download HLS playlist for video file
        /// </summary>
        public async Task<string> DownloadHlsPlaylist(DownloadHlsPlaylistRequest request)
        {
            return await _apiClient.ExecuteGetAsync<string>($"files/{request.FileId}/hls/media.m3u8", request);
        }

        /// <summary>
        /// Delete files
        /// </summary>
        public async Task DeleteFiles(DeleteFilesRequest request)
        {
            await _apiClient.ExecutePostAsync("files/delete", request);
        }

        /// <summary>
        /// Upload a files
        /// </summary>
        public async Task UploadFile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List active extractions
        /// </summary>
        public async Task<ListExtractionsResponse> ListExtractions()
        {
            return await _apiClient.ExecuteGetAsync<ListExtractionsResponse>("files/extract");
        }

        /// <summary>
        /// Extract ZIP and RAR archives
        /// </summary>
        public async Task<ExtractionsResponse> Extract(ExtractionRequest request)
        {
            return await _apiClient.ExecutePostAsync<ExtractionsResponse>("files/extract", request);
        }

        /// <summary>
        /// Set the position of a video
        /// </summary>
        public async Task SetVideoPosition(SetVideoPositionRequest request)
        {
            await _apiClient.ExecutePostAsync($"files/{request.FileId}/start-from", request);
        }

        /// <summary>
        /// Deleted the position of a video
        /// </summary>
        public async Task DeleteVideoPosition(DeleteVideoPositionRequest request)
        {
            await _apiClient.ExecutePostAsync($"files/{request.FileId}/start-from");
        }
    }
}