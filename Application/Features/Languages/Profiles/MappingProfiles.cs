using Application.Features.Languages.Commands;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language,CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, GetByIdLanguageQuery>().ReverseMap();
            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
            CreateMap<Language, LanguageGetListDto>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageGetListDto>().ReverseMap();
            CreateMap<UpdateLanguageCommand, Language>().ReverseMap();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
            CreateMap<Language, DeleteLanguageDto>().ReverseMap();













        }
    }
}
