using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PutIo.Sharp.Extensions;

namespace PutIo.Sharp.Models.Files.Requests
{
    public class CreateFolderRequest :PutIoPostRequest
    {
        public CreateFolderRequest(string name, long parentId)
        {
            Name = name;
            ParentId = parentId;
        }
        
        /// <summary>
        /// The name of the new folder
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// the parent of the folder
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long ParentId { get; set; }
        
        internal override string Serialize()
        {
            if (Name is null || Name.IsEmptyOrAllSpaces())
                throw new ArgumentException($"Name of new folder cannot be null or empty");

            return JsonSerializer.Serialize(this);
        }
    }
}