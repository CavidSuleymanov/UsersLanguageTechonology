using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGitHubProfileCommandValidator : AbstractValidator<UpdateGitHubProfileCommand>
    {
        public UpdateGitHubProfileCommandValidator()
        {
            RuleFor(c => c.GitHubUrl).NotEmpty();
        }
    }
}
