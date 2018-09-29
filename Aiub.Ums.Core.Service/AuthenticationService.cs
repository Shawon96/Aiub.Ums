using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiub.Ums.Core.Service.Interfaces;

namespace Aiub.Ums.Core.Service
{
    public class AuthenticationService: IAuthenticationService
    {
        public bool Authenticate(string userId, string password)
        {
            if (userId.Equals(password)) //fake implementation
                return true;
            return false;
        }
    }
}
