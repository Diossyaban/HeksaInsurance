using Heksa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Heksa.Controllers
{
    public class WorkExperienceControllers : Controller
    {
        private readonly HeksaContext _context;

        public WorkExperienceControllers(HeksaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> WorkExperiences(string searchString, string currentFilter, string sortOrder, int? page, int? pageSize)
        {
            try
            {
                int pageIndex = page ?? 1;
                int defaultSize = pageSize ?? 20;
                ViewBag.psize = defaultSize;

                if (!string.IsNullOrEmpty(searchString))
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.currentfilter = searchString;

                var query = _context.WorkExperiences.AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query
                        .Where(y =>
                            (y.Agen != null && y.Agen.ToString().ToLower().Contains(searchString.ToLower())) ||
                            (y.Position != null && y.Position.ToLower().Contains(searchString.ToLower()))
                        );
                }

                ViewBag.CurrentSort = sortOrder;
                ViewBag.SortOrder = sortOrder == "Position" ? "" : "Position";

                switch (sortOrder)
                {
                    case "Position":
                        query = query.OrderBy(y => y.Position);
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
        public async Task<IActionResult> Create([Bind("AgenId,Field,Position,StartDate,EndDate,JobDesc")] WorkExperience workExperience)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    workExperience.CreateDate = DateTime.Now;
                    workExperience.CreateBy = "diossyaban";
                    TempData["SuccessMessage"] = "Work Experience successfully created.";

                    _context.WorkExperiences.Add(workExperience);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
            }

            return View(workExperience);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences.FirstOrDefaultAsync(m => m.WorkExperienceId == id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

    }
}
