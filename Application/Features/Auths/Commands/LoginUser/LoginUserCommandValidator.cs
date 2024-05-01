using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(r=>r.UserForLoginDto.Email).NotEmpty();
            RuleFor(r => r.UserForLoginDto.Password).NotEmpty();

        }
    }
}
