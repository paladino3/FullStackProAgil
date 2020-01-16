using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Api.Dtos;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.Api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase {
        private readonly IProAgilRepository _repo;
        private readonly IMapper _mapper;

        public EventoController (IProAgilRepository repo, IMapper mapper) {
           _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {

            try {
                var eventos = await _repo.GetAllEventosAsync (true);

                var results = _mapper.Map<IEnumerable<EventoDto>>(eventos);

                return Ok (results);

            } catch (System.Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, $"Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde! {ex.Message}");
            }

        }

        [HttpGet ("{EventoId}")]
        public async Task<IActionResult> Get (int EventoId) {

            try {
                var evento = await _repo.GetEventosAsyncById (EventoId, true);

                var results = _mapper.Map<EventoDto>(evento);

                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }

        }

        [HttpGet ("getByTema/{tema}")]
        public async Task<IActionResult> Get (string tema) {

            try {
                var results = await _repo.GetAllEventosAsyncByTema (tema, true);
                return Ok (results);
            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post (Evento model) {

            try {
                _repo.Add (model);

                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/api/evento/{model.Id}", model);
                }

            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
            return BadRequest ();
        }

        [HttpPut ("{EventoId}")]
        public async Task<IActionResult> Put (int EventoId, Evento model) {
            try {
                var evento = await _repo.GetEventosAsyncById (EventoId, false);

                if (evento == null) return NotFound ();

                _repo.Update (model);

                if (await _repo.SaveChangesAsync ()) {
                    return Created ($"/api/evento/{model.Id}", model);
                }

            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
            return BadRequest ();
        }

        [HttpDelete ("{EventoId}")]
        public async Task<IActionResult> Delete ([FromRoute] int EventoId) {
            try {
                var evento = await _repo.GetEventosAsyncById (EventoId, false);

                if (evento == null) return NotFound ();

                _repo.Delete (evento);

                if (await _repo.SaveChangesAsync ()) {
                    return Ok ();
                }

            } catch (System.Exception) {
                return this.StatusCode (StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
            return BadRequest ();
        }
    }
}