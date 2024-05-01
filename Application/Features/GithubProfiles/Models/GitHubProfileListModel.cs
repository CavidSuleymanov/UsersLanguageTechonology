using Application.Features.GithubProfiles.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Models
{
    public class GitHubProfileListModel : BasePageableModel
    {
        public IList<GitHubProfileListDto> Items { get; set; }
    }
}
