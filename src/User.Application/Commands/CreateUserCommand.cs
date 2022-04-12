using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Responses;

namespace User.Application.Commands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}
