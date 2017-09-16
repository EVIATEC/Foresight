using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Platform.ApiGateways.WebGateway.Models
{
    [DataContract]
    public class StorageFileVersion
    {
        [DataMember]
        public long FileVersionId { get; set; }

        [DataMember]
        public virtual StorageFile File { get; set; }

        [DataMember]
        public long FileId { get; set; }

        [DataMember]
        public long StorageId { get; set; }

        [DataMember]
        public string VersionNumber { get; set; }

        [DataMember]
        public string VersionComment { get; set; }
        
        public string SubPath { get; set; }
        
        public Guid FileGuid { get; set; }

        [DataMember]
        public long FileSizeInBytes { get; set; }

        [DataMember]
        public string Extension { get; set; }

        [DataMember]
        public DateTimeOffset Created { get; set; }

        [DataMember]
        public DateTimeOffset LastAccess { get; set; }

        [DataMember]
        public string HashSha256 { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        public string OriginalFileName { get; set; }
    }
}
