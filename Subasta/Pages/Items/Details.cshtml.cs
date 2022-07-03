using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Subasta.Data;
using Subasta.Models;

namespace Subasta.Pages.Subastas
{
    public class DetailsModel : PageModel
    {
        private readonly Subasta.Data.SubastaContext _context;

        public DetailsModel(Subasta.Data.SubastaContext context)
        {
            _context = context;
        }

        public Item Item { get; set; } = default!;
        public IList<Puja> Puja { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            if (_context.Puja != null)
            {
                Puja = await _context.Puja.Where(x => x.ItemID == id)
                    .OrderByDescending(s => s.PujaMonto)
                    .ToListAsync();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            else 
            {
                Item = item;
            }
            return Page();
        }


 
    }
}
