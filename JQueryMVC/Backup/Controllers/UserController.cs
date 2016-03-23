using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryMVC.Models;

namespace JQueryMVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            var model = UserRepository.Users;
            return View(model);
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            var model = UserRepository.Users.First(user => user.UserID == id);
            return View(model);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var user = new User();
                UpdateModel(user);
                UserRepository.Users.Add(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = UserRepository.Users.First(user => user.UserID == id);
            return View(model);
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = UserRepository.Users.First(user => user.UserID == id);
            try
            {
           
                UpdateModel(model);

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Country", "This is useless message attached to the 'Country' input");
                return View(model);
            }
        }

        //
        // POST/GET: /User/Delete/5
        public void Delete(int id)
        {
            var model = UserRepository.Users.First(user => user.UserID == id);
            UserRepository.Users.Remove(model);
        }

        //
// POST/GET: /User/Search
public ActionResult Search(bool? active, int? rating)
{
    var model = UserRepository.Users.Where(user => user.IsActive == active && user.Rating > rating);
    return View("Index", model);
}
    }
}
