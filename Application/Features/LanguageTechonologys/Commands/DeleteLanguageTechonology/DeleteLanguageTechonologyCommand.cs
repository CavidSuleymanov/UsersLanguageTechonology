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

namespace Application.Features.LanguageTechonologys.Commands.DeleteLanguageTechonology
{
    public class DeleteLanguageTechonologyCommand:IRequest<DeleteLanguageTechonologyDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageTechonologyCommandHandler : IRequestHandler<DeleteLanguageTechonologyCommand, DeleteLanguageTechonologyDto>
        {

            private readonly ILanguageTechonologyRepository _languageTechonologyRepository;
            private readonly IMapper _mapper;

            public DeleteLanguageTechonologyCommandHandler(ILanguageTechonologyRepository languageTechonologyRepository, IMapper mapper)
            {
                _languageTechonologyRepository = languageTechonologyRepository;
                _mapper = mapper;
            }
            public async Task<DeleteLanguageTechonologyDto> Handle(DeleteLanguageTechonologyCommand request, CancellationToken cancellationToken)
            {
             LanguageTechonolgy? languageTechonology = await  _languageTechonologyRepository.GetAsync(b=>b.Id==request.Id);
                LanguageTechonolgy deletedLanguageTechonology = await  _languageTechonologyRepository.DeleteAsync(languageTechonology);
                DeleteLanguageTechonologyDto deleteLanguageTechonologyDto= _mapper.Map<DeleteLanguageTechonologyDto>(deletedLanguageTechonology);
                return deleteLanguageTechonologyDto;
            }
        }
    }
}
