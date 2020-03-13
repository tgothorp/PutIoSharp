using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PutIo.Sharp.Models.Shared
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FileSort
    {
        [EnumMember(Value = "NAME_ASC")]
        NameAscending,
        [EnumMember(Value = "NAME_DESC")]
        NameDescending,
        [EnumMember(Value = "SIZE_ASC")]
        SizeAscending,
        [EnumMember(Value = "SIZE_DESC")]
        SizeDescending,
        [EnumMember(Value = "DATE_ASC")]
        DateCreatedAscending,
        [EnumMember(Value = "DATE_DESC")]
        DateCreatedDescending,
        [EnumMember(Value = "MODIFIED_ASC")]
        DateModifiedAscending,
        [EnumMember(Value = "MODIFIED_DESC")]
        DateModifiedDescending,
    }
}