using System;
using System.Collections.Generic;

namespace Aiub.Ums.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }

        //public virtual ICollection<Section> Sections { get; set; }
    }
}
