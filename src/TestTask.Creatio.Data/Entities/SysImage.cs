using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SysImage : BaseEntity
    {
        public DateTime? UploadedOn { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public bool HasRef { get; set; }

        public byte[] PreviewData { get; set; }
    }
}
