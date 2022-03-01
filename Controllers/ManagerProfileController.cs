using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentersLife.Controllers
{
    public class ManagerProfileController : Controller
    {
        // GET: ManagerProfileController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerProfileController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ManagerProfileController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
