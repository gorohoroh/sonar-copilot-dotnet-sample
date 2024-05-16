using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;


namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IRestaurantData _restaurantData;


        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
          
            return View(model);
        }


        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;


                newRestaurant = _restaurantData.Add(newRestaurant);


                return RedirectToAction("Details", new {id = newRestaurant.Id});
            }

            return View();
        }
    }
}