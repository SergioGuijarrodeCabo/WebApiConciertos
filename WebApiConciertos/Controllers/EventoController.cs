using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiConciertos.Models;
using WebApiConciertos.Repositories;

namespace WebApiConciertos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private RepositoryEventos repo;

        public EventoController(RepositoryEventos repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<List<Evento>> GetEventos()
        {
            return await this.repo.GetEventosAsync();
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<List<CategoriaEvento>> GetCategorias()
        {
            return await this.repo.GetCategoriaEventosAsync();
        }


        [HttpGet("{idcategoria}")]
        public async Task<List<Evento>> GetEventosCategorias(int idcategoria)
        {
            return await this.repo.GetEventosporCategoriaAsync(idcategoria);
        }



        [HttpPost]
        public async Task<ActionResult> CreateEvento(Evento evento)
        {
            await this.repo.CreateEvento(evento.Nombre, evento.Artista, evento.IdCategoria ,evento.Imagen);
            return Ok();
        }

    }
}
