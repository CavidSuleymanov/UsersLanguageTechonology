using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimCanNotBeDublicateted(string name)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(claim => claim.Name == name);
            if (result != null)
                throw new BusinessException("Claim name exists.");
        }

        public async Task OperationClaimShouldExistWhenRequested(OperationClaim? claim)
        {
            if (claim == null)
                throw new BusinessException("This Id does not exists.");
        }
    }
}
