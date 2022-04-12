using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Commands;
using User.Application.Mappers;
using User.Application.Responses;

namespace User.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _UserRepo;


        public CreateUserHandler(IUserRepository UserRepository)
        {
            _UserRepo = UserRepository;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var UserEntitiy = UserMapper.Mapper.Map<User.Core.Entities.User>(request);
            if (UserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newUser = await _UserRepo.AddAsync(UserEntitiy);

            var UserResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return UserResponse;
        }
    }
}
