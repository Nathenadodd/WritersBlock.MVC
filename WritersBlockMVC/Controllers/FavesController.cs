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
            var userId = Guid.Parse(User.Identity.GetUserId());
            FavesService service = new FavesService(userId);
            var model = service.GetFaves();
            

            return View(model);
        }
        public ActionResult Create()
        {
            var service = CreateFavesService();
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");
            var CommentsList = service.CreateCommentSelectList();
            ViewBag.CommentsList = new SelectList(CommentsList, "Value", "Text");
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaveCreate model)
        {
            var service = CreateFavesService();
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");
            var CommentsList = service.CreateCommentSelectList();
            ViewBag.CommentsList = new SelectList(CommentsList, "Value", "Text");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var service = CreateFavesService();

           if (service.CreateFave(model))
           {
                ViewBag.SaveResult = "Your fave  was created";
                return RedirectToAction("Index");
           };
            ModelState.AddModelError("", "Fave could not be created");

            return View(model);
            
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
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");
            var CommentsList = service.CreateCommentSelectList();
            ViewBag.CommentsList = new SelectList(CommentsList, "Value", "Text");
            var model =
                new FavesEdit
                {
                    FaveID = detail.FaveID,
                    PostID = detail.PostID,
                    CommentID = detail.CommentID,
                    UserID = detail.UserID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FavesEdit model)
        {
            var service = CreateFavesService();
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");
            var CommentsList = service.CreateCommentSelectList();
            ViewBag.CommentsList = new SelectList(CommentsList, "Value", "Text");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.FaveID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            //var svc = CreateFavesService();
            //var detail = svc.GetFavesById(id);
            //model = new FavesEdit
            //{
            //    FaveID = detail.FaveID
            //};

            if (service.UpdateFaves(model))
            {
                ViewBag.SaveEdit = "Fave was updated.";
            }
            return RedirectToAction(nameof(Index));
        }
            //ModelState.AddModelError("", "Your note could not be updated.");
            //return View(model);

        
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
        public ActionResult DeleteFave(int id)
        {
            var service = CreateFavesService();

            service.DeleteFave(id);

            TempData["SaveResult"] = "Your Fave was deleted";

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