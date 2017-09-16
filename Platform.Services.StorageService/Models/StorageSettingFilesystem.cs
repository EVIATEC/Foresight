using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.StorageService.Models
{
    public class StorageSettingFilesystem
    {
        public long StorageSettingFilesystemId { get; set; }

        [Required]
        public long StorageId { get; set; }

        [Required]
        public Storage Storage { get; set; }

        [Required]
        public String BasePath { get; set; }

        [Required]
        [Range(10000, long.MaxValue)]
        public long MaxElements { get; set; }

    }
}
