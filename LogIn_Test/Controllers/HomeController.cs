using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement;

namespace LogIn_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            if(ModelState.IsValid)
            {
               if( UserManagement.Authentication.IsAuthenticated(u.Username, u.Password, 13))
                {
                    Session["LogedUserID"] = UserManagement.Authentication.UserName;
                    Session["LogedUserFullname"] = UserManagement.Authentication.FirstName+" " + UserManagement.Authentication.LastName; 
                    return RedirectToAction("AfterLogin");
                }
                /*using (PMEntities dc=new PMEntities())
                {
                    var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if(v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }*/
            }
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            ViewBag.LogedUser = Session["LogedUserFullname"];
            if (Session["LogedUserID"] != null)
            {
                var entities = new Models.PMEntities1();
                return View(entities.PM_vw_InspectorView);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Check()
        {
            return View();
        }

        public ActionResult Submit(string id)
        {
            return View();
        }
    }
}