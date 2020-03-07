using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PutIo.Sharp.Models.Shared;

namespace PutIo.Sharp.Models.Account
{
    public class AccountInfo
    {
        [JsonPropertyName("account_active")]
        public bool AccountActive { get; set; }
        
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        
        [JsonPropertyName("can_create_sub_account")]
        public bool CanCreateSubAccount { get; set; }
        
        [JsonPropertyName("can_invite_friend")]
        public bool CanInviteFriend { get; set; }
        
        [JsonPropertyName("days_until_files_deletion")]
        public long DaysUntilFilesDeletion { get; set; }
        
        [JsonPropertyName("disk")]
        public Disk Disk { get; set; }
        
        [JsonPropertyName("family_owner")]
        public string FamilyOwner { get; set; }
        
        [JsonPropertyName("files_will_be_deleted_at")]
        public DateTime? FilesWillBeDeletedAt { get; set; }
        
        [JsonPropertyName("has_voucher")]
        public bool HasVoucher { get; set; }
        
        [JsonPropertyName("is_invited_friend")]
        public bool IsInvitedFriend { get; set; }
        
        [JsonPropertyName("is_sub_account")]
        public bool IsSubAccount { get; set; }
        
        [JsonPropertyName("mail")]
        public string Mail { get; set; }
        
        [JsonPropertyName("oauth_token_id")]
        public long OauthTokenId { get; set; }
        
        [JsonPropertyName("plan_expiration_date")]
        public DateTime? PlanExpirationDate { get; set; }
        
        [JsonPropertyName("private_download_host_ip")]
        public string PrivateDownloadHostIp { get; set; }
        
        [JsonPropertyName("settings")]
        public AccountSettings AccountSettings { get; set; }
        
        [JsonPropertyName("simultaneous_download_limit")]
        public long SimultaneousDownloadLimit { get; set; }
        
        [JsonPropertyName("subtitle_languages")]
        public List<SubtitleLanguage> SubtitleLanguages { get; set; }
        
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
        
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}