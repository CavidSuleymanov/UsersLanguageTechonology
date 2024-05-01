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

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
        {

            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }
            public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(b => b.Id == request.Id);
                await _languageBusinessRules.LanguageShouldExistWhenRequested(language);
                Language mappedLanguage = _mapper.Map<Language>(language);
                Language deletedLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                DeleteLanguageDto deleteLanguageDto = _mapper.Map<DeleteLanguageDto>(deletedLanguage);
                return deleteLanguageDto;

            }
        }
    }
}
