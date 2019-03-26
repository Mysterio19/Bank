using System;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.Web.Extensions;
using Bank.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult ViewAll()
        {
            var model = new CommentModels();
            var comments = _commentService.GetFirst10Comments();
            model.Comments = comments.Select(CommentModel.From);
            
            return View(model);
        }
        
        public IActionResult Create(CommentModel model)
        {
            if (!ModelState.IsValid) return View("ViewAll");

            try
            {
                _commentService.Create(model.To(User.GetId()));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return RedirectToAction("ViewAll");
        }
    }
}