using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TenderDbContext _context;

        public UserRepository(TenderDbContext tenderDbContext)
        {
            _context = tenderDbContext;
        }
     
        public User GetUser(string userName,string password)
        {
            return this._context.Users.ToList().Where(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase) && u.Password.Equals(password,StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }
    }
}
