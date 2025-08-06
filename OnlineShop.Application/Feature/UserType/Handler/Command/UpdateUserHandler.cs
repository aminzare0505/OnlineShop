using AutoMapper;
using MediatR;
using OnlineShop.Application.Feature.UserType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.UserType.Handler.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, VoidResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<VoidResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var userEntity =await _userRepository.GetUserById(request.UpdateUserDto.Id);

            var user  = _mapper.Map(request.UpdateUserDto, userEntity);
            await _userRepository.Update(user);
            return VoidResult.VoidSuccessResult();
        }
    }
}
