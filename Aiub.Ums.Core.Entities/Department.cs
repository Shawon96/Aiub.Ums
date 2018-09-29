using System.Collections.Generic;

namespace Aiub.Ums.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
    }
}
