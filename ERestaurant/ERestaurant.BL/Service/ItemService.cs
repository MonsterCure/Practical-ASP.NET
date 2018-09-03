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
    public class ItemService : BaseService<ItemRepository>, IService<DtoItem>
    {
        public ServiceResult<DtoItem> Add(DtoItem item)
        {
            try
            {
                if(Context.Categories.Any(c => c.CategoryId == item.CategoryId))
                {
                    var result = Repository.Create(new Item()
                    {
                        ItemName = item.ItemName,
                        ItemPrice = item.ItemPrice,
                        ItemDescription = item.ItemDescription,
                        ItemContents = item.ItemContents,
                        ItemAvailability = item.ItemAvailability,
                        CategoryId = item.CategoryId
                    });

                    return new ServiceResult<DtoItem>()
                    {
                        Item = new DtoItem(result),
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoItem>()
                    {
                        Success = false,
                        ErrorMessage = "There is no category with the specified category ID."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> Edit(DtoItem item)
        {
            try
            {
                if (Context.Categories.Any(c => c.CategoryId == item.CategoryId))
                {
                    Repository.Update(new Item()
                    {
                        ItemName = item.ItemName,
                        ItemPrice = item.ItemPrice,
                        ItemDescription = item.ItemDescription,
                        ItemContents = item.ItemContents,
                        ItemAvailability = item.ItemAvailability,
                        CategoryId = item.CategoryId
                    });

                    return new ServiceResult<DtoItem>()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoItem>()
                    {
                        Success = false,
                        ErrorMessage = "There is no category with the specified category ID."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> Load(DtoItem item)
        {
            try
            {
                var result = Repository.GetById(item.ItemId);

                return new ServiceResult<DtoItem>()
                {
                    Item = new DtoItem(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> LoadAll()
        {
            try
            {
                var items = Repository.GetAll().ToList();
                var resultList = new List<DtoItem>();
                items.ForEach(i => resultList.Add(new DtoItem(i))); //mapping the object from Data into the object from Service

                return new ServiceResult<DtoItem>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> Remove(DtoItem item)
        {
            try
            {
                if (Context.Categories.Any(c => c.CategoryId == item.CategoryId))
                {
                    Repository.Delete(new Item()
                    {
                        ItemName = item.ItemName,
                        ItemPrice = item.ItemPrice,
                        ItemDescription = item.ItemDescription,
                        ItemContents = item.ItemContents,
                        ItemAvailability = item.ItemAvailability,
                        CategoryId = item.CategoryId
                    });

                    return new ServiceResult<DtoItem>()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new ServiceResult<DtoItem>()
                    {
                        Success = false,
                        ErrorMessage = "There is no category with the specified category ID."
                    };
                }
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
