using Application.Features.LanguageTechonologys.Models;
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

namespace Application.Features.LanguageTechonologys.Queries
{
    public  class GetListLanguageTechonologyQuery:IRequest<LanguageTechonolgyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTechonologyQueryHandler : IRequestHandler<GetListLanguageTechonologyQuery, LanguageTechonolgyListModel>
        {
            private readonly ILanguageTechonologyRepository _languageTechonologyRepository;
            private readonly IMapper _mapper;

            public GetListLanguageTechonologyQueryHandler(ILanguageTechonologyRepository languageTechonologyRepository, IMapper mapper)
            {
                _languageTechonologyRepository = languageTechonologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechonolgyListModel> Handle(GetListLanguageTechonologyQuery request, CancellationToken cancellationToken)
            {
             IPaginate<LanguageTechonolgy> languageTechonology= await  _languageTechonologyRepository.GetListAsync(include:
                 c=>c.Include(m=>m.Language),
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize);
                LanguageTechonolgyListModel mappedLanguageTechonology =  _mapper.Map<LanguageTechonolgyListModel>(languageTechonology);
                return mappedLanguageTechonology;
            }
        }
    }
}
