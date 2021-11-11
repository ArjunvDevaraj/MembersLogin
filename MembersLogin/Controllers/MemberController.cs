
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
 

namespace MembersLogin.Controllers
{
    public class MemberController : SurfaceController
    {
        private const string PARTIAL_VIEW_HOME_FOLDER = "~/Views/Partials/";
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult MemberLogin()
        {
            return PartialView(PARTIAL_VIEW_HOME_FOLDER + "MemberLogin.cshtml");
        }


            [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid) {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    UrlHelper urlHelper = new UrlHelper(HttpContext.Request.RequestContext);
                    if(urlHelper.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else return Redirect("/");
                }
                else {
                    ModelState.AddModelError("", "Invalid Credenstials");
                        }
            }
            //return CurrentUmbracoPage();
            ModelState.AddModelError("", "Error");
            return null;
        }
        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        

    }
}
