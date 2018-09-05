using System.Collections.Generic;

namespace ERestaurant.Data.Repository
{
    public interface IRepository<T>
    {
        //Read
        IList<T> GetAll(); // if IQueryable, the action to get info from the base would be executed (with .ToList(), for example) somewhere outside of the Data layer (in the Service layer, etc.), which is not desirable

        T GetById(int id);

        //Write
        T Create(T item);

        void Update(T item);

        void Delete(T item);

        //void Delete(int Id);
    }
}
