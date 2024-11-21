using FluentValidation;
using LivrosApp.DOMAIN.Dtos;
using LivrosApp.DOMAIN.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LivrosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LivroResponseDto), 201)]
        public IActionResult Post([FromBody] LivroRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
            }

            try
            {
                var response = _livroService.IncluirLivro(dto);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new { Name = e.PropertyName, Error = e.ErrorMessage });
                return BadRequest(errors);
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LivroResponseDto), 200)]
        public IActionResult Put(Guid id, [FromBody] LivroRequestDto dto)
        {
            try
            {
                var response = _livroService.AlterarLivro(id, dto);
                return Ok(response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new { Name = e.PropertyName, Error = e.ErrorMessage });
                return BadRequest(errors);
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _livroService.ExcluirLivro(id);
                return NoContent();
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LivroResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _livroService.ObterPorId(id);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(LivroResponseDto), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _livroService.ConsultarTodosOsLivros();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        [HttpPut("retirar")]
        [ProducesResponseType(typeof(List<LivroResponseDto>), 200)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult RetirarLivros([FromBody] List<Guid> ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                {
                    return UnprocessableEntity(new { message = "A lista de IDs não pode ser vazia." });
                }

                var response = _livroService.RetirarLivros(ids);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }


        [HttpPut("devolver/{id}")]
        [ProducesResponseType(typeof(LivroResponseDto), 200)]
        public IActionResult DevolverLivro(Guid id)
        {
            try
            {
                var response = _livroService.DevolverLivro(id);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
