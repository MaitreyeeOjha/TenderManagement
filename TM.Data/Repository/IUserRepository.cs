using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Repository
{
    public interface IUserRepository
    {
        User GetUser(string userName,string password);
    }
}
