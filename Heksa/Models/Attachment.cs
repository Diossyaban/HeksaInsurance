using System;
using System.Collections.Generic;

#nullable disable

namespace Heksa.Models
{
    public partial class Attachment
    {
        public long AttachmentId { get; set; }
        public long? AgenId { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }

        public virtual Agen Agen { get; set; }
    }
}
