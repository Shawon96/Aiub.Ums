using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class CourseSectionsVM
    {
        public CourseSectionsVM()
        {
            Sections = new List<Section>();
        }

        public Course Course{ get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}