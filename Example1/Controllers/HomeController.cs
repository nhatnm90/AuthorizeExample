using Example1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        
        [Authorize]
        public ActionResult ListUser()
        {
            var model = new ViewModel.UserViewModel();
            model.ListOfUser = _userRepository.GetAllUser();
            return View(model);
        }
    }
}
