using System;
using System.Data.Entity;

namespace ERestaurant.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationDbContext DbContext => _dbContext; //wrapper/auto property

        public BaseRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public static void InitializeDatabase()
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }
        
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
