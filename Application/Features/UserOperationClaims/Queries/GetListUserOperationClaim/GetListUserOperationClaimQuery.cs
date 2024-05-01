using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {

            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public GetListUserOperationClaimQueryHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> models = await _userOperationClaimRepository.GetListAsync(include:
                                              m => m.Include(c => c.User).Include(c => c.OperationClaim),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                UserOperationClaimListModel mappedUserOperationClaims = _mapper.Map<UserOperationClaimListModel>(models);
                return mappedUserOperationClaims;
            }
        }
    }
}
