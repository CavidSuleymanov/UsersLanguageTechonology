using Application.Features.Languages.Commands;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);

        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdateLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Created("", result);

        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeleteLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Created("", result);

        }



        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto result=await Mediator.Send(getByIdLanguageQuery);
            return Ok(result);
        }

    }
}
