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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            var service = CreatePostService();
            var model = service.GetPosts();

            return View(model);
        }
        //GET: Create viewpage
        public ActionResult Create()
        {
            var service = CreatePostService();
            return View();
        }
        //[Route("/Post/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                ViewBag.SaveResult = "Your post was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Post could not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostById(id);
            var model =
                new PostEdit
                {
                    PostID = detail.PostID,
                    PostText = detail.PostText,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PostID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var svc = CreatePostService();
            //var detail = svc.GetPostById(id);
            //model = new PostEdit
            //{
            //    PostText = detail.PostText
            //};

            if (svc.UpdatePost(model, id))
            {
                ViewBag.SaveEdit = "Post was updated.";
            }    
        return RedirectToAction(nameof(Index));

            }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();

            service.DeletePost(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}
