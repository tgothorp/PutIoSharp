using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Files
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FileType
    {
        [EnumMember(Value = "FOLDER")]
        Folder,
        [EnumMember(Value = "FILE")]
        File,
        [EnumMember(Value = "AUDIO")]
        Audio,
        [EnumMember(Value = "VIDEO")]
        Video,
        [EnumMember(Value = "IMAGE")]
        Image,
        [EnumMember(Value = "ARCHIVE")]
        Archive,
        [EnumMember(Value = "PDF")]
        Pdf,
        [EnumMember(Value = "TEXT")]
        Text,
        [EnumMember(Value = "SWF")]
        Swf,
    }
}