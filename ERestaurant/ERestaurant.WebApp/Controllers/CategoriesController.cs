using ERestaurant.BL.Model;
using ERestaurant.BL.Service;
using System.Web.Mvc;
 
namespace ERestaurant.WebApp.Controllers
{
    public class CategoriesController : Controller 
    { 
        CategoryService _categoriesService; 

        public CategoriesController() 
        { 
            _categoriesService = new CategoryService(); 
        } 

        [HttpPost] 
        [ActionName("create")] 
        public ActionResult CreateCategory(DtoCategory request) 
        { 
            ServiceResult<DtoCategory> result = _categoriesService.Add(request); 
            if (result.Success) 
                return Json(result.Item); 
            return new HttpStatusCodeResult(400, result.ErrorMessage); 
        }
    }
}
