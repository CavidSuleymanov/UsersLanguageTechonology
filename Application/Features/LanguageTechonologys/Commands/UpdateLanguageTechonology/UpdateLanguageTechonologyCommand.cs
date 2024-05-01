using Application.Features.LanguageTechonologys.Commands.CreateLanguageTechonology;
using Application.Features.LanguageTechonologys.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Commands.UpdateLanguageTechonology
{
    public  class UpdateLanguageTechonologyCommand:IRequest<UpdateLanguageTechonolgyDto>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageTechonologyCommandHandler : IRequestHandler<UpdateLanguageTechonologyCommand, UpdateLanguageTechonolgyDto>
        {

            private readonly ILanguageTechonologyRepository _languageTechonologyRepository;
            private readonly IMapper _mapper;

            public UpdateLanguageTechonologyCommandHandler(ILanguageTechonologyRepository languageTechonologyRepository, IMapper mapper)
            {
                _languageTechonologyRepository = languageTechonologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateLanguageTechonolgyDto> Handle(UpdateLanguageTechonologyCommand request, CancellationToken cancellationToken)
            {
               //LanguageTechonolgy? languageTechonolgy =await _languageTechonologyRepository.GetAsync(c=>c.Id==request.Id);
               // LanguageTechonolgy mappedLanguageTechnology = _mapper.Map<LanguageTechonolgy>(languageTechonolgy);

               // UpdateLanguageTechonologyCommand updateLanguageTechonologyCommand= _mapper.Map<UpdateLanguageTechonologyCommand>(mappedLanguageTechnology);
                LanguageTechonolgy mappedLanguageTechonology= _mapper.Map<LanguageTechonolgy>(request);
                LanguageTechonolgy updatedLanguageTechnology= await _languageTechonologyRepository.UpdateAsync(mappedLanguageTechonology);
                UpdateLanguageTechonolgyDto updateLanguageTechonolgyDto= _mapper.Map<UpdateLanguageTechonolgyDto>(updatedLanguageTechnology);
                return updateLanguageTechonolgyDto;
            }
        }
    }
}
