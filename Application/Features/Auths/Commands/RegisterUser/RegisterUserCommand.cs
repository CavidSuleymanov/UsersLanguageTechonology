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

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public  class RegisterUserCommand :IRequest<RegisteredDto>
    {
     public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RegisteredDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
               await _authBusinessRules.UserRegisteredNameCanNotBeDuplicatedWhenInserted(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                    
                };
                User createdUser =  await _userRepository.AddAsync(user);

               RefreshToken createdRefreshToken=  await _authService.CreateRefreshToken(createdUser,request.IpAddress);
                RefreshToken adddRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
               AccessToken accessToken= await _authService.CreateAccessToken(createdUser);
                RegisteredDto registeredDto = new()
                {
                    AccessToken = accessToken,
                   RefreshToken = adddRefreshToken
                };

                return registeredDto;

            }
        }
    }
}
