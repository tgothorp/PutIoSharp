using System.Collections.Generic;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Account.Requests
{
    public class UpdateAccountSettingsRequest
    {
        /// <summary>
        /// The id of the folder that should be the default download folder (0 is the root directory).
        /// </summary>
        [JsonPropertyName("default_download_folder")]
        public long DefaultDownloadFolder { get; set; }
        
        /// <summary>
        /// Setting this to true will mark the account as being offline to people in the friends list.
        /// </summary>
        [JsonPropertyName("is_invisible")]
        public bool IsInvisible { get; set; }
        
        /// <summary>
        /// The default subtitle language that should be used when watching videos.
        /// </summary>
        [JsonPropertyName("default_subtitle_language")]
        public SubtitleLanguage DefaultSubtitleLanguage { get; set; }

        /// <summary>
        /// The secondary language to use for subtitles.
        /// </summary>
        [JsonIgnore]
        public SubtitleLanguage SecondarySubtitleLanguage { get; set; }

        [JsonPropertyName("subtitle_languages")]
        public IEnumerable<SubtitleLanguage> SubtitleLanguages => new SubtitleLanguage[]
        {
            DefaultSubtitleLanguage,
            SecondarySubtitleLanguage
        }; 
    }
}