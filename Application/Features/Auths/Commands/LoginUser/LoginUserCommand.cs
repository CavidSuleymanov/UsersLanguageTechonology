using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
          public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

              User? user= await  _userRepository.GetAsync(e=>e.Email==request.UserForLoginDto.Email);

                _authBusinessRules.CheckVerifyPassword(request.UserForLoginDto.Password,user.PasswordHash,user.PasswordSalt);

              
                AccessToken accessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken adddRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                LoginDto loginDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = adddRefreshToken
                };

                return loginDto;

            }
        }
    }
}
