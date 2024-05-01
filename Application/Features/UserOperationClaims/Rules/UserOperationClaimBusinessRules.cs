using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository)
        {
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
        }

        public async Task OperationShouldExist(int operationClaimId)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(claim => claim.Id == operationClaimId);
            if (operationClaim == null) throw new BusinessException("This Operation does not exists.");
        }

        public async Task UserShouldExist(int userId)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user == null) throw new BusinessException("This User does not exists.");
        }

        public async Task UserOperationClaimCanNotBeDublicateted(UserOperationClaim userOperationClaim)
        {
            UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(uoc => uoc.UserId == userOperationClaim.UserId && uoc.OperationClaimId == userOperationClaim.OperationClaimId);
            if (result != null)
                throw new BusinessException("This User has this claim");
        }

        public async Task UserOperationClaimShouldExistWhenRequested(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null)
                throw new BusinessException("This Id does not exists.");
        }
    }
}
