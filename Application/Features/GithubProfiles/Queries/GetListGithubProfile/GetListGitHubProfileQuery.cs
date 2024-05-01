using Application.Features.GithubProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Queries.GetListGithubProfile
{
    public class GetListGitHubProfileQuery : IRequest<GitHubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListModelQueryHandler : IRequestHandler<GetListGitHubProfileQuery, GitHubProfileListModel>
        {

            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public GetListModelQueryHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
            }

            public async Task<GitHubProfileListModel> Handle(GetListGitHubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> gitHubProfiles = await _gitHubProfileRepository.GetListAsync(include:
                                              m => m.Include(c => c.User),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                GitHubProfileListModel mappedGitHubProfiles = _mapper.Map<GitHubProfileListModel>(gitHubProfiles);
                return mappedGitHubProfiles;
            }
        }
    }
}
