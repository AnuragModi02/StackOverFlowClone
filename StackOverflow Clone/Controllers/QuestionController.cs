
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BuissnessLayer.ViewModels;
using BuissnessLayer;
using BuissnessLayer.Models;
using BuissnessLayer.IdentityModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace StackOverflow_Clone.Controllers
{
    public class QuestionController : Controller
    {
        ApplicationContext _context;
        public QuestionController()
        {
            _context = new ApplicationContext();
             ViewBag.Current = "Question";
        }

        [AllowAnonymous]
        public ActionResult GetQuestions()
        {
            List<Question> questions = _context.Questions.Select(x => x).ToList();

            ViewBag.TotalQuestions = questions.Count;

            foreach(Question question in questions)
            {
                _context.Questions.Include(x => x.Appuser).ToList();
                _context.Questions.Include(x => x.Tags).ToList();
                _context.Questions.Include(x => x.Answers).ToList();
            }

            return View(questions);

        }

        public ActionResult IncreaseVote(int Id)
        {
            Question question = _context.Questions.FirstOrDefault(x => x.Id == Id);
            question.Votes += 1;
            _context.SaveChanges();

            return RedirectToAction("GetAnswer", "Answer", new { id = Id }) ;
        }

        public ActionResult DecreaseVote(int Id)
        {
            Question question = _context.Questions.FirstOrDefault(x => x.Id == Id);
            question.Votes -= 1;
            _context.SaveChanges();

            return RedirectToAction("GetAnswer", "Answer", new { id = Id });
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            TempData["CreateQuestion"] = true;
            if(User.Identity.IsAuthenticated)
            {
                    return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult CreateQuestion(QuestionViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            if (ModelState.IsValid)
            {
                Question question = new Question();

                question.Questions = model.Title;
                question.Description = question.Questions;

                question.Tags = CreateTags(model.Tags);

                question.Appuser = userManager.FindByName(User.Identity.Name);

                _context.Questions.Add(question);
                _context.SaveChanges();

                return RedirectToAction("GetQuestions");                
            }
            return View();
        }

        private List<Tags> CreateTags(string tags)
        {
            List<Tags> listOfTags = new List<Tags>();
            tags = tags.Trim();
            string[] tag = tags.Split(' ');
            SortedSet<string> set = new SortedSet<string>(tag);

            foreach (string tagg in set)
            {
                listOfTags.Add(new Tags()
                {
                    TagName = tagg
                });
            }

            return listOfTags;
        }
    }
}