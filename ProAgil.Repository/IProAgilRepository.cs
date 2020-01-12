using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {   
        //geral
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();
         
        //eventos
        Task<Evento[]>GetAllEventosAsyncByTema(string tema, bool includePalestrante);
        Task<Evento[]>GetAllEventosAsync(bool includePalestrante);
        Task<Evento>GetEventosAsyncById(int EventoId, bool includePalestrante);

        //palestrantes
        Task<Palestrante[]>GetAllPalestranteAsyncByNome(string nome, bool includeEventos);
        Task<Palestrante>GetPalestrantesAsync(int PalestranteId, bool includeEventos);


    }
}