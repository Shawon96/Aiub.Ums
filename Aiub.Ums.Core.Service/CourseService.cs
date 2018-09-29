using System.Data.Entity;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public sealed class CourseService : ServiceBase<Course>, ICourseService
    {
        public CourseService(DbContext context) : base(context) { }
    }
}