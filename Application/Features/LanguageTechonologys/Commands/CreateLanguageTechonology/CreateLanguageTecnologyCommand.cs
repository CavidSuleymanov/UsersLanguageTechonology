using Application.Features.LanguageTechonologys.Dtos;
using Application.Features.LanguageTechonologys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Commands.CreateLanguageTechonology
{
    public class CreateLanguageTecnologyCommand : IRequest<CreateLanguageTechonolgyDto>
    {

        public int LanguageId { get; set; }
        public string Name { get; set; }

        public class CreateLanguageTecnologyCommandHandler : IRequestHandler<CreateLanguageTecnologyCommand, CreateLanguageTechonolgyDto>
        {

            private readonly ILanguageTechonologyRepository _languageTechonologyRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechonologyBusinessRules _languageTechonologyBusinessRules;

            public CreateLanguageTecnologyCommandHandler(ILanguageTechonologyRepository languageTechonologyRepository, IMapper mapper, LanguageTechonologyBusinessRules languageTechonologyBusinessRules)
            {
                _languageTechonologyRepository = languageTechonologyRepository;
                _mapper = mapper;
                _languageTechonologyBusinessRules = languageTechonologyBusinessRules;
            }

            public async Task<CreateLanguageTechonolgyDto> Handle(CreateLanguageTecnologyCommand request, CancellationToken cancellationToken)
            {

                await _languageTechonologyBusinessRules.LanguageTechonologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                LanguageTechonolgy mappedLanguageTechonology = _mapper.Map<LanguageTechonolgy>(request);
                LanguageTechonolgy createdLanguageTechonolgy = await _languageTechonologyRepository.AddAsync(mappedLanguageTechonology);
                CreateLanguageTechonolgyDto createdLanguageTechonolgyDto = _mapper.Map<CreateLanguageTechonolgyDto>(createdLanguageTechonolgy);

                return createdLanguageTechonolgyDto;
            }
        }
    }
}
