using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum SubtitleFormat
    {
        [EnumMember(Value = "srt")]
        SRT,
        [EnumMember(Value = "webvtt")]
        WEBVTT
    }
}