using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Rules
{
    public class GitHubProfileBusinessRules
    {
        private readonly IGitHubProfileRepository _gitHubProfileRepository;
        private readonly IUserRepository _userRepository;

        public GitHubProfileBusinessRules(IGitHubProfileRepository gitHubProfileRepository, IUserRepository userRepository)
        {
            _gitHubProfileRepository = gitHubProfileRepository;
            _userRepository = userRepository;
        }

        public async Task UserShouldExistWhenGitHubProfileCreated(int userId)
        {
            User? result = await _userRepository.GetAsync(u => u.Id == userId);

            if (result == null)
                throw new BusinessException("UserId does not exist.");
        }

        public async Task UserShouldExistWhenRequested(GitHubProfile gitHubProfile)
        {
            if (gitHubProfile == null) throw new BusinessException("Requested gitHub profile does not exists");
        }

        public async Task GitHubProfileShouldExistWhenRequested(GitHubProfile gitHubProfile)
        {
            if (gitHubProfile == null) throw new BusinessException("Requested gitHub profile does not exists");
        }
    }
}
