namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {   
        //geral
         void add<T>(T entity) where T: class;

    }
}