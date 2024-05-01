using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGitHubProfileCommand : IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }

        public class
            DeleteGitHubProfileCommandHandler : IRequestHandler<DeleteGitHubProfileCommand, DeletedGitHubProfileDto>
        {
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GitHubProfileBusinessRules _gitHubProfileBusinessRules;

            public DeleteGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, GitHubProfileBusinessRules gitHubProfileBusinessRules)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
                _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
            }

            public async Task<DeletedGitHubProfileDto> Handle(DeleteGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile? gitHubProfile = await _gitHubProfileRepository.GetAsync(g => g.Id == request.Id);

                _gitHubProfileBusinessRules.GitHubProfileShouldExistWhenRequested(gitHubProfile);

                GitHubProfile deletedGitHubProfile = await _gitHubProfileRepository.DeleteAsync(gitHubProfile);
                DeletedGitHubProfileDto deletedGitHubProfileDto =
                    _mapper.Map<DeletedGitHubProfileDto>(deletedGitHubProfile);

                return deletedGitHubProfileDto;
            }
        }
    }
}
