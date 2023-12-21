using Heksa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Heksa.Controllers
{

    public class AgenController : Controller
    {
        private readonly HeksaContext _context;

        public AgenController(HeksaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AgenList(string searchString, string currentFilter, string sortOrder, int? page, int? pageSize)
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

            var x = await _context.Agens.ToListAsync();
            ViewBag.currentfilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                x = x
                    .Where(y =>
                        (y.Name != null && y.Name.ToLower().Contains(searchString.ToLower())) || //number 1 schizo country in the world for a reason
                        (y.Address != null && y.Address.ToLower().Contains(searchString.ToLower())) ||
                        (y.Email != null && y.Email.ToLower().Contains(searchString.ToLower()))
                    )
                    .ToList();
            }


            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortOrder = sortOrder == "Name" ? "" : "Name";





            return View(x.ToPagedList(pageIndex, defaultSize));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegDate,RegStatus,Name,Gender,BirthPlace,BirthDate,Address,Email,Phone,IdCard,CreateDate,CreateBy")] Agen agen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agen);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Agen successfully created.";

                return RedirectToAction(nameof(AgenList));
            }

            return View(agen);
        }

        // GET: Agen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agen = await _context.Agens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agen == null)
            {
                return NotFound();
            }

            return View(agen);
        }

        // GET: Agen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agen = await _context.Agens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agen == null)
            {
                return NotFound();
            }

            return View(agen);
        }

        // POST: Agen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agen = await _context.Agens.FindAsync(id);
            if (agen == null)
            {
                return NotFound();
            }

            _context.Agens.Remove(agen);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Agen successfully deleted.";

            return RedirectToAction(nameof(AgenList));
        }

    }

}