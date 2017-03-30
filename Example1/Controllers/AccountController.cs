using Example1.Models;
using Example1.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace Example1.Views
{
    public class AccountController : Controller
    {
        private UserRepository _userRepository;

        public AccountController()
        {
            _userRepository = new UserRepository();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (_userRepository.Validate(model.Name, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                return RedirectToAction("ListUser", "Home");
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
