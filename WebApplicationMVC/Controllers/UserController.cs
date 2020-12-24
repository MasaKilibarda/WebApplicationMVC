using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC.Models;


namespace WebApplicationMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Proveri(User user)
        {
            using (DBFModel db=new DBFModel()) {
                var userDet = db.User.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (userDet == null)
                {
                    user.ErrorMessage = "Pogresno ime ili lozinka";
                    return View("Index", user);
                }
               else {
                    
                    Session["userID"] = userDet.UserId;
                   
                    Session["role"] = userDet.Role;
                   
                    return RedirectToAction("Index", "Home");
                }
                
              
            }
                
        }

        public ActionResult Izgloguj()
        {
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }


    }
}