using System;
using System.Collections.Generic;

#nullable disable

namespace Heksa.Models
{
    public partial class WorkExperience
    {
        public long WorkExperienceId { get; set; }
        public long? AgenId { get; set; }
        public string Field { get; set; }
        public string Position { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobDesc { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }

        public virtual Agen Agen { get; set; }
    }
}
