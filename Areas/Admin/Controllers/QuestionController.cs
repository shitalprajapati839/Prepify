using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prepify.Models;
using Prepify.Repository;

namespace Prepify.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]


    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _repo;
        private readonly ApplicationDbContext _context;

        public QuestionController(IQuestionRepository repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        // 🔹 LIST ALL QUESTIONS
        public IActionResult Index()
        {
            var questions = _repo.GetAll();
            return View(questions);
        }
        [HttpGet]
        // 🔹 CREATE GET
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // 🔹 CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question q)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Categories = _context.Categories.ToList();
                return View(q);
            }

            _repo.Add(q);
            _repo.Save();

            return RedirectToAction("Index");
        }
        [HttpGet]
        // 🔹 EDIT GET
        public IActionResult Edit(int id)
        {
            var question = _repo.Get(id);

            if (question == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(question);
        }

        // 🔹 EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Question q)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(q);
            }

            _repo.Update(q);
            _repo.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        // 🔹 DELETE GET
        public IActionResult Delete(int id)
        {
            var question = _repo.Get(id);

            if (question == null)
                return NotFound();

            return View(question);
        }

        // 🔹 DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.Save();

            return RedirectToAction("Index");
        }
    }
}
