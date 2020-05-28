using DVDWebApi.Data.DataFactories;
using DVDWebApi.Models;
using System.Collections.Generic;
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
            var dvd = new Dvd();

            return View(dvd);
        }

        [HttpPost]
        public ActionResult Add(Dvd dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            repo.Insert(dvd);

            if (!ModelState.IsValid)
                return View(dvd);

            return RedirectToAction("GetAll");
        }

        public ActionResult Edit(int id)
        {
            Dvd dvd = new Dvd();

            var dvdsRepo = DvdRepositoryFactory.GetRepository();

            dvd = dvdsRepo.GetById(id);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult Edit(Dvd dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            repo.Update(dvd);

            if (!ModelState.IsValid)
                return View(dvd);

            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            repo.Delete(id);

            return RedirectToAction("GetAll");
        }
    }
}