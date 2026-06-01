using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prepify.Models;
using System.Security.Claims;

namespace Prepify.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var results = _context.Results
                .OrderByDescending(r => r.AttemptedAt)
                .ToList();


            return View(results);
        }
    }
}
