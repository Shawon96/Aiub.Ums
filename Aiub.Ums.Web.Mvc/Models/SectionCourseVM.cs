using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class SectionCourseVM
    {
        public Section Section { get; set; }
        public Course Course { get; set; }
    }
}