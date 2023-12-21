using Heksa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Heksa.Controllers
{
    public class EducationController : Controller
    {
        private readonly HeksaContext _context;

        public EducationController(HeksaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Educations(string searchString, string currentFilter, string sortOrder, int? page, int? pageSize)
        {
            try
            {
                int pageIndex = page ?? 1;
                int defaultSize = pageSize ?? 20;
                ViewBag.psize = defaultSize;

                IQueryable<Education> query = _context.Educations.AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.currentfilter = searchString;

                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query
                        .Where(y =>
                            (y.Agen != null && y.Agen.ToString().Contains(searchString.ToLower())) ||
                            (y.Institution != null && y.Institution.ToLower().Contains(searchString.ToLower()))
                        );
                }

                ViewBag.CurrentSort = sortOrder;
                ViewBag.SortOrder = sortOrder == "Agen" ? "" : "Agen";

                switch (sortOrder)
                {
                    case "Agen":
                        query = query.OrderBy(y => y.Agen);
                        break;

                    default:
                        break;
                }

                var result = await query.ToPagedListAsync(pageIndex, defaultSize);

                return View(result);
            }
            catch (Exception ex)
            {
                return View("Error");
            }



        }


            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Education education)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        education.CreateDate = DateTime.Now;
                        education.CreateBy = "diossyaban"; 
                        _context.Add(education);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Education record created successfully.";
                        return RedirectToAction(nameof(Educations));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the education record.");
                }

                return View(education);
            }
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .FirstOrDefaultAsync(m => m.EducationId == id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }
    }
}
