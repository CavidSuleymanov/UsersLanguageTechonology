using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Rules
{
    public class LanguageTechonologyBusinessRules
    {

        private readonly ILanguageTechonologyRepository _languageTechonologyRepository;

        public LanguageTechonologyBusinessRules(ILanguageTechonologyRepository languageTechonologyRepository)
        {
            _languageTechonologyRepository = languageTechonologyRepository;
        }

        public async Task LanguageTechonologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<LanguageTechonolgy> result = await _languageTechonologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("LanguageTechonology name exists.");
        }

        public async Task LanguageRechonologyNameCanNotBeEmptyWhenInserted(string name)
        {
            if (name == "") throw new BusinessException("LanguageTechonology name cannot be empty");
        }
        public async Task LanguageTechonologyShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested LanguageTechonology does not exist.");
        }
    }
}
