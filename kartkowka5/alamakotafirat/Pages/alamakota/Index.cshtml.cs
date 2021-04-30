using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace alamakotafirat.Pages_alamakota
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGameContext _context;

        public IndexModel(RazorPagesGameContext context)
        {
            _context = context;
        }

        public IList<alamakota> alamakota { get;set; }

        public async Task OnGetAsync()
        {
            alamakota = await _context.alamakota.ToListAsync();
        }
    }
}
