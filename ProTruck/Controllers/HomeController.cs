using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProTruck.Entity;
using ProTruck.ViewModel;
using System.Diagnostics;

namespace ProTruck.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
        //returns the user to the home page
        public IActionResult Index()
        {
            return View();
        }

        //Catalogue gets all the trucks from the database and redirects the user to the catalogue with the information
        public IActionResult Catalogue()
        {
            Context context = new Context();
            CatalogueModel model = new CatalogueModel();
            model.Trucks = context.Trucks.ToList();
            return View(model);
        }

        //GetImage is the method that gets the photo from the wwwroot folder and returns it to the view
        public FileResult GetImage(int id)
        {
            Context context = new Context();
            Truck truck = context.Trucks.Find(id);

            string rootPath = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(rootPath + "\\img\\trucks\\", truck.fileName + ".png");

            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/png");
        }

        //Details gets the information about the specified truck and redirects the user to the view with the information about the truck
        public IActionResult Details(int id)
        {
            Context context = new Context();
            DetailsModel model = new DetailsModel();
            model.item = context.Trucks.Find(id);

            if (model.item == null)
                return RedirectToAction("Catalogue");

            return View(model);
        }

        //Contact refirects the user to the view
        public IActionResult Contact()
        {
            return View();
        }

        //Login GET redirects the user to the view
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Login POST Checks if the user that is trying to log in is registered into the database
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Context context = new Context();    

            foreach (var item in context.Users)
            {
                if (item.username.Equals(model.username) && item.password.Equals(model.password))
                {
                    LoggedUser.user = item;
                }
            }

            if (LoggedUser.user == null)
                return View(model);

            return RedirectToAction("Index");
        }

        //Register GET redirects the user to the view
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Register POST inserts the user to the database
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Context context = new Context();
            User user = new User();
            user.username = model.username;
            user.password = model.password;

            context.Users.Add(user);
            context.SaveChanges();

            LoggedUser.user = user;

            return RedirectToAction("Index");
        }

        //Logout removes the loged user from the static class
        public IActionResult Logout()
        {
            LoggedUser.user = null;
            return RedirectToAction("Index");
        }
    }
}