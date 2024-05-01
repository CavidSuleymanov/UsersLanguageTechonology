using Application.Features.GithubProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Queries.GetListGithubProfileByDynamic
{
    public class GetListGitHubProfileByDynamicQuery : IRequest<GitHubProfileListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListGitHubProfileByDynamicQueryHandler : IRequestHandler<GetListGitHubProfileByDynamicQuery, GitHubProfileListModel>
        {

            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public GetListGitHubProfileByDynamicQueryHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
            {
                _mapper = mapper;
                _gitHubProfileRepository = gitHubProfileRepository;
            }

            public async Task<GitHubProfileListModel> Handle(GetListGitHubProfileByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> models = await _gitHubProfileRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              m => m.Include(c => c.User),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                GitHubProfileListModel mappedGitHubProfiles = _mapper.Map<GitHubProfileListModel>(models);
                return mappedGitHubProfiles;
            }
        }
    }
}
