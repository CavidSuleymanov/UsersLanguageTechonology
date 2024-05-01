using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands
{
    public class UpdateLanguageCommand:IRequest<UpdateLanguageDto>
    {
        public int Id { get; set; }
        public string? Name { get; set;}

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedLanguage= _mapper.Map<Language>(request);

               Language cretedLanguage= await _languageRepository.UpdateAsync(mappedLanguage);
                await _languageBusinessRules.LanguageShouldExistWhenRequested(cretedLanguage);

                UpdateLanguageDto updateLanguageDto =  _mapper.Map<UpdateLanguageDto>(cretedLanguage);
                return updateLanguageDto;
                 


            }
        }
            
        }
    }

