using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationclaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimCanNotBeDublicateted(request.Name);

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(claim => claim.Id == request.Id);
                await _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);
                operationClaim.Name = request.Name;
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);

                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
                return updatedOperationClaimDto;
            }
        }
    }
}
