using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Repositories;
using User.Infrastructure.Data;
using User.Infrastructure.Repositories.Base;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : Repository<User.Core.Entities.User>, IUserRepository
    {
        public UserRepository(UserContext UserContext) : base(UserContext) { }
        public async Task<IEnumerable<Core.Entities.User>> GetUserByLastName(string lastname)
        {
            return await _UserContext.Users.Where(m => m.LastName == lastname).ToListAsync();
        }
    }
}
