using System.Data.Entity;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public sealed class DepartmentService : ServiceBase<Department>, IDepartmentService
    {
        public DepartmentService(DbContext context) : base(context) { }
    }
}
