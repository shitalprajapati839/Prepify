using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prepify.Models;

namespace Prepify.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]

    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var questions = _context.Questions.ToList();
            return View(questions);
        }
        public IActionResult Start()
        {
            var questions = _context.Questions.ToList();
            return View(questions);
        }


        [HttpPost]
        public IActionResult Submit(Dictionary<int, string> answers)
        {
            var questions = _context.Questions.ToList();

            int score = 0;
            if (answers == null || answers.Count < questions.Count)
            {
                TempData["Error"] = "Please answer all questions!";
                return RedirectToAction("Start");
            }
            if (answers == null || answers.Count < questions.Count)
            {
                TempData["Error"] = "Please answer all questions!";
                return RedirectToAction("Start");
            }
            foreach (var q in questions)
            {
                if (answers.ContainsKey(q.QuestionId))
                {
                    if (answers[q.QuestionId] == q.Answer)
                    {
                        score++;
                    }
                }
            }
            var result = new UserQuizResult
            {
                UserId = "Guest",
                Score = score,
                total = questions.Count,
                AttemptedAt = DateTime.Now
            };

            _context.Results.Add(result);
            _context.SaveChanges();


            ViewBag.Score = score;
            ViewBag.Total = questions.Count;
            ViewBag.UserAnswers = answers;

            return View("Result", questions);

        }
    }
}
