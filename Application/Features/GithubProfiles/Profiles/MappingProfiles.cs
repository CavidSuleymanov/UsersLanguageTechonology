using Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubProfile, CreatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, CreateGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, UpdatedGitHubProfileDto>().ReverseMap();
            CreateMap<GitHubProfile, UpdateGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, DeletedGitHubProfileDto>().ReverseMap();
            CreateMap<IPaginate<GitHubProfile>, GitHubProfileListModel>().ReverseMap();

            CreateMap<GitHubProfile, GitHubProfileListDto>()
                .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.User.Id))
                .ReverseMap();
        }
    }
}
