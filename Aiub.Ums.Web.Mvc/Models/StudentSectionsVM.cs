using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Web.Mvc.Models
{
    public class StudentSectionsVM
    {
        public StudentSectionsVM()
        {
            Sections = new List<Section>();
        }

        public Student Student { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}