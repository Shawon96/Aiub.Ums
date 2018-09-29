using Aiub.Ums.Core.Entities;
using System.Collections.Generic;

namespace Aiub.Ums.Core.Service.Interfaces
{
    public interface IStudentService : IService<Student>
    {
        IEnumerable<Student> GetByIdOrName(string searchKey);
    }
}
