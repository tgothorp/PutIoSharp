using System.Collections.Generic;
using System.Threading.Tasks;
using PutIo.Sharp.Models.Files;
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
            return await _apiClient.ExecuteGetWithResponseAsync<ListFilesResponse>($"files/list", request);
        }

        /// <summary>
        /// Fetch remaining files by cursor
        /// </summary>
        public async Task<ListFilesContinueResponse> ListFilesContinue(ListFilesContinueRequest request)
        {
            return await _apiClient.ExecutePostWithResponseAsync<ListFilesContinueResponse>($"files/list/continue", request);
        }

        /// <summary>
        /// Search the users files and the files of user's friends
        /// </summary>
        public async Task<SearchFilesResponse> SearchFiles(SearchFilesRequest request)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<SearchFilesResponse>($"files/search", request);
        }

        /// <summary>
        /// Retrieve the remaining search results via cursor 
        /// </summary>
        public async Task<SearchFilesContinueResponse> SearchFilesContinue(SearchFilesContinueRequest request)
        {
            return await _apiClient.ExecutePostWithResponseAsync<SearchFilesContinueResponse>("files/search/continue", request);
        }

        /// <summary>
        /// Creates a folder
        /// </summary>
        public async Task<File> CreateFolder(CreateFolderRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<CreateFolderResponse>("files/create-folder", request);
            return response.NewFolder;
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
        public async Task<Mp4> Mp4ConversionStatus(Mp4ConversionStatusRequest request)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<Mp4ConversionStatusResponse>($"files/{request.FileId}/mp4");
            return response.Mp4;
        }

        /// <summary>
        /// Get available subtitles for a file for user's preferred language
        /// </summary>
        public async Task<List<Subtitle>> ListSubtitles(SubtitlesRequest request)
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<SubtitlesResponse>($"files/{request.FileId}/subtitles");
            return response.Subtitles;
        }

        /// <summary>
        /// Download a subtitle file
        /// </summary>
        public async Task<string> DownloadSubtitles(DownloadSubtitlesRequest request)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<string>($"files/{request.FileId}/subtitles/{request.Key}", request);
        }

        /// <summary>
        /// Download HLS playlist for video file
        /// </summary>
        public async Task<string> DownloadHlsPlaylist(DownloadHlsPlaylistRequest request)
        {
            return await _apiClient.ExecuteGetWithResponseAsync<string>($"files/{request.FileId}/hls/media.m3u8", request);
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
        public async Task UploadFile(UploadFileRequest request)
        {
            await _apiClient.UploadFileAsync(request);
        }

        /// <summary>
        /// List active extractions
        /// </summary>
        public async Task<List<Extraction>> ListExtractions()
        {
            var response = await _apiClient.ExecuteGetWithResponseAsync<ListExtractionsResponse>("files/extract");
            return response.Extractions;
        }

        /// <summary>
        /// Extract ZIP and RAR archives
        /// </summary>
        public async Task<List<Extraction>> Extract(ExtractionRequest request)
        {
            var response = await _apiClient.ExecutePostWithResponseAsync<ExtractionsResponse>("files/extract", request);
            return response.Extractions;
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