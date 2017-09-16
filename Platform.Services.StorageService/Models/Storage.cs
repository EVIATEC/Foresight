using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.StorageService.Models
{
    public enum StorageType
    {
        filesystem = 1
    }

    public class Storage
    {
        public long StorageId { get; set; }

        public string Name { get; set; }

        public StorageType Type { get; set; }
    }
}
