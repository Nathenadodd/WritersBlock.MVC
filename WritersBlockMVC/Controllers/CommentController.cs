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
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            CommentService service = new CommentService(userId);
            var model = service.GetComments();

            return View(model);
        }
        //GET: Create ViewPage
        public ActionResult Create()
        {
            var service = CreateCommentService();
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            var service = CreateCommentService();
            var PostsList = service.CreatePostSelectList();
            ViewBag.PostsList = new SelectList(PostsList, "Value", "Text");

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var userId = User.Identity.GetUserId();
            //var service = CreateCommentService();

           if (service.CreateComment(model))
           {
                ViewBag.SaveResult = "Your comment was created.";
                return RedirectToAction("Index");
           };

            ModelState.AddModelError("", "Comment could not be created.");

            return View(model);
                        
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentById(id);
            var model =
                new CommentEdit
                {
                    
                    CommentID = detail.CommentID,
                    PostID = detail.PostID,
                    CommentText = detail.CommentText,
                    UserID = detail.UserID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.CommentID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var svc = CreateCommentService();
            //var detail = svc.GetCommentById(id);
            //model = new CommentEdit
            //{
            //    CommentText = detail.CommentText
            //};

            if (svc.UpdateComment(model, id))
            {
                ViewBag.SaveEdit = "Comment was updated.";
            }
            //return View(model);
            return RedirectToAction(nameof(Index));
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();

            service.DeleteComment(id);

            TempData["SaveResult"] = "Your Comment was deleted";

            return RedirectToAction("Index");
        }
        

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }

    }
}