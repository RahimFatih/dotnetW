using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace alamakotafiratdenis.Pages_alamakota
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public EditModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(alamakota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alamakotaExists(alamakota.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool alamakotaExists(int id)
        {
            return _context.alamakota.Any(e => e.ID == id);
        }
    }
}
