using System;
using System.Collections.Generic;

namespace Aiub.Ums.Core.Entities
{    
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cgpa { get; set; }
        public int DepartmentId { get; set; }

        //public virtual Department Department { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        //public virtual ICollection<Registration> Registrations { get; set; }
    }
}
