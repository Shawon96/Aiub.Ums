using System.Data.Entity;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public sealed class SectionService : ServiceBase<Section>, ISectionService
    {
        public SectionService(DbContext context) : base(context) { }
    }
}
