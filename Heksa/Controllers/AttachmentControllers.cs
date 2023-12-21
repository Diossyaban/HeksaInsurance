using Heksa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Heksa.Controllers
{
    [Route("Attachment")]
    public class AttachmentControllers : Controller
    {
        private readonly HeksaContext _context;

        public AttachmentControllers(HeksaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AttachmentsList(string searchString, string currentFilter, string sortOrder, int? page, int? pageSize)
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

                var query = _context.Attachments.AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query
                        .Where(y =>
                            (y.Agen != null && y.Agen.ToString().Contains(searchString.ToLower())) ||
                            (y.FileName != null && y.FileName.ToLower().Contains(searchString.ToLower()))
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

        // POST: Attachment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentId,AgenId,FileType,FileName,FilePath,CreateDate,CreateBy")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                attachment.CreateDate = DateTime.Now;
                attachment.CreateBy = "diossyaban";
                _context.Add(attachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AttachmentsList));
            }
            return View(attachment);
        }
    }
}
