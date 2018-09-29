using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public sealed class StudentService : ServiceBase<Student>, IStudentService
    {
        public StudentService(DbContext context) : base(context) { }

        public IEnumerable<Student> GetByIdOrName(string searchKey)
        {
            try
            {
                var result = from std in Context.Set<Student>()
                    where std.Id.ToLower().Contains(searchKey.ToLower()) || std.Name.ToLower().Contains(searchKey.ToLower())
                    select std;
                return result.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}