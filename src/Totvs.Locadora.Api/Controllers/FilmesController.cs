using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Locadora.Api.ViewModels;
using Totvs.Locadora.Core.Models;
using Totvs.Locadora.Infrastructure;

namespace Totvs.Locadora.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeServicos _rep;
        private readonly IMapper _mapper;

        public FilmesController(IFilmeServicos repo, IMapper mapper)
        {
            _rep = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> RetornaTodos()
        {
            IEnumerable<FilmeViewModel> filmes = _mapper.Map<IEnumerable<FilmeViewModel>>(await _rep.RetornaTodos());

            if (!filmes.Any()) return NotFound("Não encontramos nenhum filme.");

            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornaPorId(int id)
        {
            Filme filme = await _rep.RetornaPorId(id);

            if (filme == null) return NotFound();

            return Ok(_mapper.Map<FilmeViewModel>(filme));
        }

        [HttpPost]
        public async Task<IActionResult> InsereFilme(FilmeViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool result = await _rep.Insere(_mapper.Map<Filme>(model));

            if (result) return Ok("Filme inserido com sucesso!");

            return BadRequest(StatusCode(500));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaFilme(FilmeViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Filme filme = await _rep.RetornaPorId(model.Id);

            if (filme == null) return NotFound($"Não encontramos nenhum filme com id = {model.Id} para atualizar.");

            bool result = await _rep.Atualiza(_mapper.Map(model, filme));

            if (result) return Ok("Filme atualizado com sucesso");

            return BadRequest(StatusCode(500));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFilme(int id)
        {
            bool result = await _rep.Remove(id);

            if (result) return Ok("Filme removido com sucesso");

            return BadRequest(StatusCode(500));
        }
    }
}
