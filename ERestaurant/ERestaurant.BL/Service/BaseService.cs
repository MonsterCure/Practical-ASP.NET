using ERestaurant.Data;
using ERestaurant.Data.Repository;
using System;

namespace ERestaurant.BL.Service
{
    public class BaseService<T> : IDisposable where T : BaseRepository
    {
        private T _repository;

        public T Repository => _repository;

        protected ApplicationDbContext Context => Repository.DbContext; // access to data layer in service layer here, because it is easier to get some info like this, instead of creating extra repositories in the services which would return a lot more data than needed

        public BaseService()
        {
            _repository = Activator.CreateInstance<T>(); //used to create instances of generic types
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
