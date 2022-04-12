using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zyberfox.challenge.api.Models
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            var u = new List<User>()
            {
                new User
                {
                    Id = new System.Guid(),
                    FirstName = "Jyothi",
                    LastName = "Puli",
                    Email = "Jyothi@af.com",
                    DateOfBirth = new System.DateTime(1981,05,23)
                },
                new User
                {
                    Id = new System.Guid(),
                    FirstName = "Test",
                    LastName = "Puli",
                    Email = "Testi@af.com",
                    DateOfBirth = new System.DateTime(1981,05,5)
                }
            };
            return u;
        }
    }
}
