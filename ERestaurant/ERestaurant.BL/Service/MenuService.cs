using ERestaurant.BL.Model;
using ERestaurant.Data.Model;
using ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.BL.Service
{
    public class MenuService : BaseService<MenuRepository>, IService<DtoMenu>
    {
        public ServiceResult<DtoMenu> Add(DtoMenu item)
        {
            try
            {
                var result = Repository.Create(new Menu()
                {
                    TypeId = (byte)item.TypeEnum,
                    RestaurantName = item.RestaurantName
                });

                return new ServiceResult<DtoMenu>()
                {
                    Item = new DtoMenu(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Edit(DtoMenu item)
        {
            try
            {
                Repository.Update(new Menu()
                {
                    TypeId = (byte)item.TypeEnum,
                    RestaurantName = item.RestaurantName
                });

                return new ServiceResult<DtoMenu>()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Load(DtoMenu item)
        {
            try
            {
                var result = Repository.GetById(item.MenuId);

                return new ServiceResult<DtoMenu>()
                {
                    Item = new DtoMenu(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> LoadAll()
        {
            try
            {
                var menus = Repository.GetAll().ToList();
                var resultList = new List<DtoMenu>();
                menus.ForEach(m => resultList.Add(new DtoMenu(m))); //mapping the object from Data into the object from Service

                return new ServiceResult<DtoMenu>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Remove(DtoMenu item)
        {
            try
            {
                Repository.Delete(new Menu()
                {
                    TypeId = (byte)item.TypeEnum,
                    RestaurantName = item.RestaurantName
                });

                return new ServiceResult<DtoMenu>()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
