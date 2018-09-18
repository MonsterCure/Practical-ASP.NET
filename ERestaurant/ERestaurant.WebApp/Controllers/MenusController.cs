using ERestaurant.BL.Model;
using ERestaurant.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERestaurant.WebApp.Controllers
{
    public class MenusController : Controller
    {
        private MenuService _menuService;
        public MenusController()  
        {
            _menuService = new MenuService();
        }
        
        // GET: Menus
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<DtoRestaurant> restaurants = _menuService.GetAllTeams().OrderBy(teamItem => teamItem.Name);

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var restaurant in restaurants)
            {
                items.Add(new SelectListItem { Text = restaurant.RestaurantName, Value = restaurant.RestaurantId.ToString() });
            }

            ViewBag.Teams = items;

            return View();
        }

        [HttpPost]
        public ActionResult Create(DtoMenu request, string nextView)
        {
            ServiceResult<DtoMenu> result = _menuService.Add(request);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                return View(request);
            }

            switch (nextView)
            {
                case "Create":
                    return RedirectToAction("Create");
                case "Index":
                    return RedirectToAction("Index");
                default:
                    return RedirectToAction("Details", new { id = result.Item.MenuId });
            }
        }
    }
}
