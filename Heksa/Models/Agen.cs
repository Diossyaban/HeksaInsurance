using System;
using System.Collections.Generic;

#nullable disable

namespace Heksa.Models
{
    public partial class Agen
    {
        public Agen()
        {
            Attachments = new HashSet<Attachment>();
            Educations = new HashSet<Education>();
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public long Id { get; set; }
        public DateTime? RegDate { get; set; }
        public string RegStatus { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdCard { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
