using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Repository
{
    public class RestaurantRepository : BaseRepository, IRepository<Restaurant>
    {
        public Restaurant Create(Restaurant item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Restaurant item)
        {
            throw new NotImplementedException();
        }

        public IList<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant item)
        {
            throw new NotImplementedException();
        }
    }
}
