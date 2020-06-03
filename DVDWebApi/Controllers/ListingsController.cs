using DVDWebApi.Data.DataFactories;
using DVDWebApi.Models;
using DVDWebApi.UI.Models;
using DVDWebApi.UI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace DVDWebApi.UI.Controllers
{
    public class ListingsController : Controller
    {
        public ActionResult GetAll()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            List<Dvd> dvds = repo.GetAll();

            return View(dvds);
        }

        public ActionResult Search()
        {
            var repo = DvdRepositoryFactory.GetRepository();

            return View(repo.GetAll());
        }

        public ActionResult Details(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            Dvd dvd = repo.GetById(id);

            return View(dvd);
        }

        public ActionResult Add()
        {
            var model = new DvdEditViewModel();
            //var dvd = new Dvd();

            return View(model.Dvd);
        }

        [HttpPost]
        public ActionResult Add(Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                var repo = DvdRepositoryFactory.GetRepository();

                repo.Insert(dvd);

                return RedirectToAction("GetAll");
            }
            else
                return View(dvd);            
        }

        public ActionResult Edit(int id)
        {
            var model = new DvdEditViewModel();
            //var model = new Dvd();

            var dvdsRepo = DvdRepositoryFactory.GetRepository();

            model.Dvd = dvdsRepo.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                var repo = DvdRepositoryFactory.GetRepository();

                repo.Update(dvd);

                return RedirectToAction("GetAll");
            }
            else
            {
                return View(dvd);
            }

        }

        public ActionResult Delete(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            repo.Delete(id);

            return RedirectToAction("GetAll");
        }
    }
}