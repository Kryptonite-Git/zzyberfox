using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zyberfox.challenge.api.Models
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
