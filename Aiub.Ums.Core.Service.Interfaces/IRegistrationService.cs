using System.Collections.Generic;
using Aiub.Ums.Core.Entities;

namespace Aiub.Ums.Core.Service.Interfaces
{
    public interface IRegistrationService : IService<Registration>
    {
        Registration GetByStudentAndSectionId(string studentId, int sectionId);
        IEnumerable<Section> GetSectionsByStudentId(string studentId);
        IEnumerable<Student> GetStudentsBySectionId(int sectionId);
    }
}