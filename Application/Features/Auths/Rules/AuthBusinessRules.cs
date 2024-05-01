using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task CheckVerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var checkpassword = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!checkpassword) throw new BusinessException("Password is not correct");
        }


        public async Task UserRegisteredNameCanNotBeDuplicatedWhenInserted(string email)
        {
            User result = await _userRepository.GetAsync(b => b.Email == email);
            if (result!=null) throw new BusinessException("User Email exists.");
        }


    }
}
