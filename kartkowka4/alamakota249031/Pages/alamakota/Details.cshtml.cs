using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace alamakota249031.Pages_alamakota
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public DetailsModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        public alamakota alamakota { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            alamakota = await _context.alamakota.FirstOrDefaultAsync(m => m.ID == id);

            if (alamakota == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
