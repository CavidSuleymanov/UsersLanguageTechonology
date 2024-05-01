using Application.Features.LanguageTechonologys.Commands.CreateLanguageTechonology;
using Application.Features.LanguageTechonologys.Commands.DeleteLanguageTechonology;
using Application.Features.LanguageTechonologys.Commands.UpdateLanguageTechonology;
using Application.Features.LanguageTechonologys.Dtos;
using Application.Features.LanguageTechonologys.Models;
using Application.Features.LanguageTechonologys.Queries;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechonologysController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add( [FromBody] CreateLanguageTecnologyCommand createLanguageTecnologyCommand)
        {
          CreateLanguageTechonolgyDto result= await  Mediator.Send(createLanguageTecnologyCommand);
            return Created("",result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]  PageRequest pageRequest)
        {
            GetListLanguageTechonologyQuery getListLanguageTechonologyQuery = new GetListLanguageTechonologyQuery { PageRequest=pageRequest};
           LanguageTechonolgyListModel result= await Mediator.Send(getListLanguageTechonologyQuery);
            return Ok(result);
        }

        [HttpPost("update")]

        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechonologyCommand updateLanguageTechonologyCommand)
        {
         UpdateLanguageTechonolgyDto result=  await Mediator.Send(updateLanguageTechonologyCommand);
            return Created("",result);
        }

        [HttpPost("delete{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechonologyCommand deleteLanguageTechonologyCommand)
        {
            DeleteLanguageTechonologyDto result = await Mediator.Send(deleteLanguageTechonologyCommand);
            return Created("", result);
        }
    }
}
