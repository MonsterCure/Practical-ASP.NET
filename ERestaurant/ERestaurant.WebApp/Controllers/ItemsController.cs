using ERestaurant.BL.Model;
using ERestaurant.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERestaurant.WebApp.Controllers
{
    public class ItemsController : Controller
    {
        private IService<DtoItem> _itemService;

        public ItemsController()
        {
            _itemService = new ItemService();
        }

        // GET: Items
        [HttpGet]
        public ActionResult Index()
        {
            var items = _itemService.LoadAll().ListItems;
            return View(items);
        }
    }
}