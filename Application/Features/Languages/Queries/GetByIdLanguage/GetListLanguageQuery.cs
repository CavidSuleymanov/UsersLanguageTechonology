using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public  class GetListLanguageQuery :IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Language> result= await _languageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                LanguageListModel languageListModel=_mapper.Map<LanguageListModel>(result);
                return languageListModel;
            }
        }
    }
}
