using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsUserAccount;

namespace fgcias.service.UserAccountServices
{
    public interface IUserAccountService
    {
        Task<UserAccountModel> AuthenticateToken(UserAccountModel userAccount, string token);
    }
}