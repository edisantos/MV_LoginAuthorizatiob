using DemoAuthentication.Application.ViewModels;
using DemoAuthentication.Infra.Data.Contexto;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using DemoAuthentication.Infra.Data.Helpers;

namespace DemoAuthentication.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContexto db = new DataContexto();

        [Authorize]
        public ActionResult Index()
        {
            var listar = db.Usuario.ToList();
            return View(listar);
        }

        //[Authorize]
        public ActionResult Registro()
        {
            
            ViewBag.User = User.Identity.Name;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Registro(Usuario model,string Senha)
        {

            if (ModelState.IsValid)
            {
                model.DataCadastro = DateTime.Now;
                model.Senha = Senha.Encrypt();
                db.Usuario.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public ActionResult Controles()
        {
            return View();
        }
       
        public ActionResult Login(string returnUrl)
        {

            var model = new _Login() { ReturUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(_Login model)
        {
            var CkUser = db.Usuario.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
            if (CkUser == null)
            {
                ModelState.AddModelError("UserName", "Usuário nao localizado!");
            }
            else
            {
                if (CkUser.Senha != model.Senha.Encrypt())
                    ModelState.AddModelError("Senha", "Senha Invalida");
            }
            if (ModelState.IsValid)
            {
                //Autenticar
                FormsAuthentication.SetAuthCookie(model.UserName, model.PermanecerLogado);
                //return RedirectToAction("Controles");
                if (!string.IsNullOrEmpty(model.ReturUrl) && Url.IsLocalUrl(model.ReturUrl))
                {
                    return Redirect(model.ReturUrl);
                }
                return RedirectToAction("Controles");
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}