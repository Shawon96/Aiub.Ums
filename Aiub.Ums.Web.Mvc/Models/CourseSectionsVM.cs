using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class CourseSectionsStudentsVM
    {
        public CourseSectionsStudentsVM()
        {
            Sections = new List<SectionStudentsVM>();
        }

        public Course Course{ get; set; }
        public ICollection<SectionStudentsVM> Sections { get; set; }
    }
}