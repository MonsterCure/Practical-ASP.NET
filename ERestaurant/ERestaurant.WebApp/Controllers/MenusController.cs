using ERestaurant.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERestaurant.WebApp.Controllers
{
    public class MenusController : Controller
    {
        public MenusController()  
        {
 
        }
        
        // GET: Menus
        [HttpGet]
        public ActionResult Index()
        {
            return View(new List<DtoMenu>() { 
                new DtoMenu {
                    Id = 1,
                    RestaurantName = "Kikiriki bar",
                    TypeEnum = MenuType.Meals
                } 
            }); 
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(new DtoMenu
            {
                Id = 1,
                RestaurantName = "Kikiriki bar",
                TypeEnum = MenuType.Meals
            });
        }
    }
}
