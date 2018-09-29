using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class StudentDepartmentVM
    {
        public Student Student { get; set; }
        public Department Department { get; set; }
    }
}