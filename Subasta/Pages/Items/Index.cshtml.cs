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
    public class IndexModel : PageModel
    {
        private readonly Subasta.Data.SubastaContext _context;

        public IndexModel(Subasta.Data.SubastaContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;
        public IList<Puja> Pujas { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Item != null)
            {
                Item = await _context.Item.ToListAsync();
            }
            if (_context.Puja != null)
            {
                Pujas = await _context.Puja.ToListAsync();
            }
        }

        public float GetPujaAsync(Item item)
        {
            float maxPuja;

            var puja = Pujas.Where(x => x.Item == item)
                    .OrderByDescending(s => s.PujaMonto).FirstOrDefault();
            if (puja != null)
                maxPuja = puja.PujaMonto;
            else
                maxPuja = item.PrecioInicial;

            return maxPuja;
        }
    }
}
