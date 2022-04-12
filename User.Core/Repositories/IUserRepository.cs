using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Core.Repositories.Base;

namespace User.Core.Repositories
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        //custom operations here
        Task<IEnumerable<User.Core.Entities.User>> GetUserByLastName(string lastname);
    }
}
