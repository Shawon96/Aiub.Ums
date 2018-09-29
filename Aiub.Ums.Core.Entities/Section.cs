using System;
using System.Collections.Generic;
    
namespace Aiub.Ums.Core.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        //public virtual Course Course { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
        //public virtual ICollection<Registration> Registrations { get; set; }
    }
}
