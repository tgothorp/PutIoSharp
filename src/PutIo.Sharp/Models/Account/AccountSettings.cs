using System.Collections.Generic;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Account
{
    public class AccountSettings
    {
        [JsonPropertyName("beta_user")]
        public bool BetaUser { get; set; }
        
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        
        [JsonPropertyName("dark_theme")]
        public bool DarkTheme { get; set; }
        
        [JsonPropertyName("default_download_folder")]
        public long DefaultDownloadFolder { get; set; }
        
        [JsonPropertyName("fluid_layout")]
        public bool FluidLayout { get; set; }
        
        [JsonPropertyName("history_enabled")]
        public bool HistoryEnabled { get; set; }
        
        [JsonPropertyName("is_invisible")]
        public bool IsInvisible { get; set; }
        
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("login_mails_enabled")]
        public bool LoginMailsEnabled { get; set; }
        
        [JsonPropertyName("next_episode")]
        public bool NextEpisode { get; set; }
        
        [JsonPropertyName("pushover_token")]
        public string PushoverToken { get; set; }
        
        [JsonPropertyName("sort_by")]
        public string SortBy { get; set; }
        
        [JsonPropertyName("start_from")]
        public bool StartFrom { get; set; }
        
        [JsonPropertyName("subtitle_languages")]
        public List<SubtitleLanguage> SubtitleLanguages { get; set; }
        
        [JsonPropertyName("theater_mode")]
        public bool TheaterMode { get; set; }
        
        [JsonPropertyName("transfer_sort_by")]
        public string TransferSortBy { get; set; }
        
        [JsonPropertyName("trash_enabled")]
        public bool TrashEnabled { get; set; }
        
        [JsonPropertyName("tunnel_route_name")]
        public string TunnelRouteName { get; set; }
        
        [JsonPropertyName("use_private_download_ip")]
        public bool UsePrivateDownloadIp { get; set; }
        
        [JsonPropertyName("video_player")]
        public string VideoPlayer { get; set; }
    }
}