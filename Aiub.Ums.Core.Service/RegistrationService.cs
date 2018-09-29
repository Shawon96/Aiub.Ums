using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public sealed class RegistrationService : ServiceBase<Registration>, IRegistrationService
    {
        public RegistrationService(DbContext context) : base(context) { }

        public Registration GetByStudentAndSectionId(string studentId, int sectionId)
        {
            try
            {
                return Context.Set<Registration>().SingleOrDefault(r => r.StudentId == studentId && r.SectionId == sectionId);
            }
            catch (Exception )
            {
                return null;
            }
        }

        public IEnumerable<Section> GetSectionsByStudentId(string studentId)
        {
            try
            {
                var result = from reg in Context.Set<Registration>()
                             where reg.StudentId == studentId
                             join sec in Context.Set<Section>() on reg.SectionId equals sec.Id
                             select sec;
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Student> GetStudentsBySectionId(int sectionId)
        {
            try
            {
                var result = from reg in Context.Set<Registration>()
                    where reg.SectionId == sectionId
                    join std in Context.Set<Student>() on reg.StudentId equals std.Id
                    select std;

                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
