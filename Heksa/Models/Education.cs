using System;
using System.Collections.Generic;

#nullable disable

namespace Heksa.Models
{
    public partial class Education
    {
        public long EducationId { get; set; }
        public long? AgenId { get; set; }
        public string Strala { get; set; }
        public string Institution { get; set; }
        public string Major { get; set; }
        public string Gpa { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }

        public virtual Agen Agen { get; set; }
    }
}
