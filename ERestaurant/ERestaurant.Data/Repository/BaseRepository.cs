using System;

namespace ERestaurant.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        private readonly RestaurantContext _dbContext;

        public RestaurantContext DbContext => _dbContext; //wrapper/auto property

        public BaseRepository()
        {
            _dbContext = new RestaurantContext();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
