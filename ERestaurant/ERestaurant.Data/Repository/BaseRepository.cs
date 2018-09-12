using System;

namespace ERestaurant.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        private readonly ApplicationDbContext _dbContext; // RestaurantContext

        public ApplicationDbContext DbContext => _dbContext; //wrapper/auto property // RestaurantContext

        public BaseRepository()
        {
            _dbContext = new ApplicationDbContext(); // RestaurantContext
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
