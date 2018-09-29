using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiub.Ums.Core.Service.Interfaces
{
    public interface IAuthenticationService
    {
        bool Authenticate(string userId, string password);
    }
}
