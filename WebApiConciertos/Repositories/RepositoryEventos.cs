using Microsoft.EntityFrameworkCore;
using WebApiConciertos.Data;
using WebApiConciertos.Models;

namespace WebApiConciertos.Repositories
{
    public class RepositoryEventos
    {


        private ConciertosContext context;

        public RepositoryEventos(ConciertosContext context)
        {
            this.context = context;
        }



        public async Task<List<CategoriaEvento>> GetCategoriaEventosAsync()
        {
            return await this.context.Categorias.ToListAsync();
        }



        public async Task<List<Evento>> GetEventosAsync()
        {
            return await this.context.Eventos.ToListAsync();
        }


        public async Task<List<Evento>> GetEventosporCategoriaAsync(int idcategoria)
        {
            return await this.context.Eventos.Where(x => x.IdCategoria == idcategoria).ToListAsync();
        }

        public async Task<bool> CreateEvento(string Nombre, string Artista, int IdCategoria, string Imagen )
        {
            int newid = await this.context.Eventos.AnyAsync() ? await this.context.Eventos.MaxAsync(x => x.IdEevento) + 1 : 1;
            Evento evento = new Evento
            {
                IdEevento = newid,
                Nombre = Nombre,
                Artista = Artista,
                IdCategoria = IdCategoria,
                Imagen = Imagen
            };

            await this.context.Eventos.AddAsync(evento);
            return await context.SaveChangesAsync() > 0;
        }

    }
}
