using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengdylan.ACE.Common.DALImplement
{
    public interface IAccountDAL
    {
        int Add(Data.Account account);

        int ValidateAccount(string name, string passWord);

        bool IsAccountRegistered(string name);
    }
}
