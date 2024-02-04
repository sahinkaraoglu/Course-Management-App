using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
   public IActionResult Index()
   {
      return View();
   }

   [HttpPost]
   public IActionResult Login(LoginModel model)
   {
      if (ModelState.IsValid)
      {

         if (model.Username == "admin" && model.Password == "123")
         {
            return Redirect("/Home/Index");
         }
         
         else
         {
            ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre.");
            return View("Index", model);
         }
      }

      return View("Index", model);
   }

   public IActionResult Welcome()
   {
      return View();
   }


}
