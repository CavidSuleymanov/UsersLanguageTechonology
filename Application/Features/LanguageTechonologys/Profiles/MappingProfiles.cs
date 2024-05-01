using Application.Features.LanguageTechonologys.Commands.CreateLanguageTechonology;
using Application.Features.LanguageTechonologys.Commands.UpdateLanguageTechonology;
using Application.Features.LanguageTechonologys.Dtos;
using Application.Features.LanguageTechonologys.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTechonolgy,CreateLanguageTechonolgyDto>().ReverseMap();
            CreateMap<LanguageTechonolgy, CreateLanguageTecnologyCommand>().ReverseMap();
            CreateMap<IPaginate<LanguageTechonolgy>, LanguageTechonolgyListModel>().ReverseMap();
            CreateMap<LanguageTechonolgy, LanguageTechonolgyListDto>().ForMember((c=>c.LanguageName),opt=>opt.MapFrom(c=>c.Language.Name)).ReverseMap();
            CreateMap<UpdateLanguageTechonologyCommand, LanguageTechonolgy>();
            CreateMap<LanguageTechonolgy, UpdateLanguageTechonolgyDto>();
            CreateMap<LanguageTechonolgy, DeleteLanguageTechonologyDto>();






        }
    }
}
