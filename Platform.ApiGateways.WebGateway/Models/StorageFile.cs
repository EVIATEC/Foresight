using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Platform.ApiGateways.WebGateway.Models
{
    [DataContract] // ensures that only properties with [DataMember] will be serialized
    public class StorageFile
    {
        [DataMember]
        public long FileId { get; set; }
        
        [DataMember]
        public long? CurrentVersionId { get; set; }

        [DataMember]
        [ForeignKey("CurrentVersionId")]
        public StorageFileVersion CurrentVersion { get; set; }

        internal List<StorageFileVersion> FileVersions{ get; set; } 
    } 
}
