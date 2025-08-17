using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Common;
using OnlineShop.Application.Dto.User.Validator;
using OnlineShop.Application.Feature.UserType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.UserType.Handler.Command
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, VoidResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper=mapper;
        }

        public async Task<VoidResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            CreateUserDtoValidation validation = new CreateUserDtoValidation(_userRepository);
            var userisvalid = await validation.ValidateAsync(request.CreateUserDto);

            if (!userisvalid.IsValid)
            {
                return VoidResult.VoidFailedResult(userisvalid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var userEntity = _mapper.Map<User>(request.CreateUserDto);

            var salt = PasswordHashExtension.GenerateSalt();

            userEntity.password = userEntity.password.Hashpassword(salt);
            userEntity.Salt = salt;
            await _userRepository.Add(userEntity);
            return VoidResult.VoidSuccessResult();
        }
    }
}
