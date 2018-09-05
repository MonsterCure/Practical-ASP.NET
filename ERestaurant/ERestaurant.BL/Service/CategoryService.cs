using ERestaurant.BL.Model;
using ERestaurant.Data.Model;
using ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERestaurant.BL.Service
{
    public class CategoryService : BaseService<CategoryRepository>, IService<DtoCategory>
    {
        //private readonly MenuRepository _menuRepository;

        //public CategoryService()
        //{
        //    _menuRepository = new MenuRepository();
        //}

        public ServiceResult<DtoCategory> Add(DtoCategory item)
        {
            try
            {
                //if (_menuRepository.GetById(item.MenuId) != null)
                //{
                if(Context.Menus.Any(m => m.MenuId == item.MenuId)) {
                    var result = Repository.Create(new Category()
                    {
                        MenuId = item.MenuId,
                        CategoryName = item.CategoryName
                    });

                    return new ServiceResult<DtoCategory>()
                    {
                        Item = new DtoCategory(result),
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoCategory>()
                    {
                        Success = false,
                        ErrorMessage = "Menu with requested ID does not exist."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Edit(DtoCategory item)
        {
            try
            {
                if (Context.Menus.Any(m => m.MenuId == item.MenuId))
                {
                    Repository.Update(new Category()
                    {
                        MenuId = item.MenuId,
                        CategoryName = item.CategoryName
                    });

                    return new ServiceResult<DtoCategory>()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoCategory>()
                    {
                        Success = false,
                        ErrorMessage = "Menu with requested ID does not exist."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Load(DtoCategory item)
        {
            try
            {
                var result = Repository.GetById(item.CategoryId);

                return new ServiceResult<DtoCategory>()
                {
                    Item = new DtoCategory(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> LoadAll()
        {
            try
            {
                var categories = Repository.GetAll().ToList();
                var resultList = new List<DtoCategory>();
                categories.ForEach(c => resultList.Add(new DtoCategory(c))); //mapping the object from Data into the object from Service

                return new ServiceResult<DtoCategory>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Remove(DtoCategory item)
        {
            try
            {
                if (Context.Menus.Any(m => m.MenuId == item.MenuId))
                {
                    Repository.Delete(new Category()
                    {
                        MenuId = item.MenuId,
                        CategoryName = item.CategoryName
                    });

                    return new ServiceResult<DtoCategory>()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoCategory>()
                    {
                        Success = false,
                        ErrorMessage = "Menu with requested ID does not exist."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
