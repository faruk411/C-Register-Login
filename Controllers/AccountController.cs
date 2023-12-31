﻿using Girişlogin.Identity;
using Girişlogin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Girişlogin.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public AccountController()
        {
            userManager=new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDatacontext()));
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model) 
        { 
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.Username;
                user.Email = model.Email;

                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach(var error in result.Errors) 
                    {
                        ModelState.AddModelError("",error);
                    }
                }
            }
            return View(model);
        }
    }
}