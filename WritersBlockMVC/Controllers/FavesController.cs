using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WritersBlock.Models;
using WritersBlock.Services;

namespace WritersBlockMVC.Controllers
{
    public class FavesController : Controller
    {
        // GET: Faves
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            var service = CreateFavesService();
            var model = service.GetFaves();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaveCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFavesService();

            service.CreateFave(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateFavesService();
            var model = svc.GetFavesById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateFavesService();
            var detail = service.GetFavesById(id);
            var model =
                new FavesEdit
                {
                    FaveID = detail.FaveID,
                    PostID = detail.PostID,
                    //CommentID = detail.CommentID,
                    //UserID = detail.UserID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FavesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FaveID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateFavesService();

            if (service.UpdateFaves(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);

        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFavesService();
            var model = svc.GetFavesById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFavesService();

            service.DeleteFave(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private FavesService CreateFavesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavesService(userId);

            return service;
        }
    }
}