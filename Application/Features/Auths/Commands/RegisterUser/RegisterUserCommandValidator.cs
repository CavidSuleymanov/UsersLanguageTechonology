using Application.Features.Users.Commands.CreateUserCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.UserForRegisterDto.Email).NotEmpty();
            RuleFor(r => r.UserForRegisterDto.Password).NotEmpty();
        }
    }
}
