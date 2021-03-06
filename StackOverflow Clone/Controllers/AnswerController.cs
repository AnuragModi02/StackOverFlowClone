
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BuissnessLayer.ViewModels;
using BuissnessLayer;
using BuissnessLayer.Models;
using Microsoft.AspNet.Identity.Owin;
using BuissnessLayer.IdentityModels;
using Microsoft.AspNet.Identity;

namespace StackOverflow_Clone.Controllers
{
    public class AnswerController : Controller
    {
        ApplicationContext _context;
        public AnswerController()
        {
            _context = new ApplicationContext();
            ViewBag.Current = "Answer";
        }
        // GET: Answer
        [AllowAnonymous]
        [Route("Answer/{Id}")]
        public ActionResult GetAnswer(int Id)
        {
            List<Question> question = _context.Questions.Where(x => x.Id == Id).Include(x => x.Tags).Include(x => x.Appuser).ToList();

            List<Answer> Answers = _context.Answers.Where(x => x.Question.Id == Id).Include(x=>x.Appuser).ToList();

            // Append question to the first answer for the retrieval
            //Answers[0].Question.Questions = question[0].Questions;
            //Answers[0].Question.Votes = question[0].Votes;
            //Answers[0].Question.Description = question[0].Description;
            //Answers[0].Question.Tags = question[0].Tags;
            //Answers[0].Question.User = question[0].User;

            return View(Answers);
        }

        [HttpPost]
        [Route("Answer")]
        public void AddAnswer(AnswerForSpecificQuestionViewModel value)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            Question question = _context.Questions.Where(x => x.Id == value.QuestionId).Include(x => x.Answers).FirstOrDefault();
            Answer answer = new Answer()
            {
                Answers = value.Answer,
                Appuser = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)
        };
            question.Answers.Add(answer);
            _context.SaveChanges();
        }
    }
}