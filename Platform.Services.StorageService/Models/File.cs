using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Platform.Services.StorageService.Models
{
    [DataContract] // ensures that only properties with [DataMember] will be serialized
    public class File
    {
        [DataMember]
        public long FileId { get; set; }
        
        [DataMember]
        public long? CurrentVersionId { get; set; }

        [DataMember]
        [ForeignKey("CurrentVersionId")]
        public FileVersion CurrentVersion { get; set; }

        internal List<FileVersion> FileVersions{ get; set; } 

        
    } 
}
