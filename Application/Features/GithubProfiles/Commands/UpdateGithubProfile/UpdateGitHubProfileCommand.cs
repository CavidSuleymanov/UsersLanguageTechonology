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

namespace Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGitHubProfileCommand : IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public string GitHubUrl { get; set; }
    }

    public class UpdateGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand, UpdatedGitHubProfileDto>
    {
        private readonly IGitHubProfileRepository _gitHubProfileRepository;
        private readonly IMapper _mapper;
        private readonly GitHubProfileBusinessRules _gitHubProfileBusinessRules;

        public UpdateGitHubProfileCommandHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper, GitHubProfileBusinessRules gitHubProfileBusinessRules)
        {
            _gitHubProfileRepository = gitHubProfileRepository;
            _mapper = mapper;
            _gitHubProfileBusinessRules = gitHubProfileBusinessRules;
        }

        public async Task<UpdatedGitHubProfileDto> Handle(UpdateGitHubProfileCommand request, CancellationToken cancellationToken)
        {
            GitHubProfile? gitHubProfile = await _gitHubProfileRepository.GetAsync(gH => gH.Id == request.Id);
            await _gitHubProfileBusinessRules.GitHubProfileShouldExistWhenRequested(gitHubProfile);
            gitHubProfile.GitHubUrl = request.GitHubUrl;
            GitHubProfile updatedGitHubProfile = await _gitHubProfileRepository.UpdateAsync(gitHubProfile);

            UpdatedGitHubProfileDto updatedGitHubProfileDto = _mapper.Map<UpdatedGitHubProfileDto>(updatedGitHubProfile);
            return updatedGitHubProfileDto;
        }
    }
}
