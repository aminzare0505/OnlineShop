using FluentValidation;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto.User.Validator
{
    public class CreateUserDtoValidation : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDtoValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.FullName).NotEmpty().WithMessage("نام نباید خالی باشد!");
            RuleFor(x => x.UserName).MustAsync(async (username, token) =>
            {
                var result = await _userRepository.CheckWithUserName(username);

                return !result;
            }).WithMessage("همچین نام کاربری موجود می باشد!");

            RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیلی که وارد کردید درست نیست!");
            RuleFor(x => x.password).Empty().WithMessage("نباید خالی باشی").Matches(@"[A-Z]+")
                .WithMessage("Your password must contain at least one uppercase letter.").MinimumLength(6)
                .WithMessage("طول پسورد شما کمتر از ۶ کارکتر می باشد!");
        }
    }
}
