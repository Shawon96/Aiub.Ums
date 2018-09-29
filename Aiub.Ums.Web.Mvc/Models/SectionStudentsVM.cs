using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class SectionStudentsVM
    {
        public SectionStudentsVM()
        {
            Students = new List<Student>();
        }

        public Section Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}