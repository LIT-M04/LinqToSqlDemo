using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LinqToSqlDemo.Data;
using LinqToSqlDemo.Models;

namespace LinqToSqlDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            return View(new IndexViewModel { People = repo.GetPeople(), Message = (string)TempData["message"] });
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Add(person);
            TempData["message"] = "New Person added, Id: " + person.Id;
            return Redirect("/home/index");
        }

        public ActionResult Edit(int personId)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            var person = repo.GetById(personId);
            return View(new EditViewModel { Person = person });
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Update(person);
            TempData["message"] = "Person updated!";
            return Redirect("/home/index");
        }

        [HttpPost]
        public void Delete(int personId)
        {
            Thread.Sleep(5000);
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Delete(personId);
        }
    }
}
