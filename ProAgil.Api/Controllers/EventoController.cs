using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

         [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var results = await _repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }

        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {

            try
            {
                var results = await _repo.GetEventosAsyncById(EventoId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }

        }

        
        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {

            try
            {
                var results = await _repo.GetAllEventosAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {

            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
                return BadRequest();
        }


        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventosAsyncById(EventoId, false);
                
                if(evento == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
                return BadRequest();
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete([FromRoute]int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventosAsyncById(EventoId, false);
                
                if(evento == null) return NotFound();

                _repo.Delete(evento);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Nao foi possivel conectar-se ao banco de dados... Tente novamente mais tarde!");
            }
                return BadRequest();
        }
    }
}