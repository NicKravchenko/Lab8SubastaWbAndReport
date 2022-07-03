using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Subasta.Data;
using Subasta.Models;

namespace Subasta.Pages.Pujas
{
    public class CreateModel : PageModel
    {
        private readonly Subasta.Data.SubastaContext _context;

        public CreateModel(Subasta.Data.SubastaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Puja Puja { get; set; } = default!;

        [BindProperty]
        public Puja MaxPuja { get; set; } = default!;

        [BindProperty]
        public Item Item { get; set; } = default!;

        [BindProperty]
        public PujaViewModel PujaVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            if (_context.Item != null)
            {
                Item = await _context.Item.Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
            }

            if (_context.Puja != null)
            {
                MaxPuja = await _context.Puja.Where(x => x.ItemID == id)
                    .OrderByDescending(s => s.PujaMonto)
                    .FirstOrDefaultAsync();
            }

            MaxPuja = await _context.Puja.Where(x => x.ItemID == id)
                    .OrderByDescending(s => s.PujaMonto)
                    .FirstOrDefaultAsync();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            MaxPuja = await _context.Puja.Where(x => x.ItemID == Item.ID)
                    .OrderByDescending(s => s.PujaMonto)
                    .FirstOrDefaultAsync();

            Item = await _context.Item.Where(x => x.ID == Item.ID)
                    .FirstOrDefaultAsync();

            if (MaxPuja == null )
            {
                if (PujaVM.PujaMonto <= Item.PrecioInicial)
                {
                    ModelState.AddModelError("Monto", $"Monto debe ser mas que {Item.PrecioInicial}");

                    //return Page();
                    return RedirectToPage("./Create", new { id = Item.ID.ToString() });
                }
                else
                {
                    PujaVM.ItemID = Item.ID;
                    PujaVM.FechaPuesto = DateTime.Now;

                    var entry = _context.Add(new Puja());
                    entry.CurrentValues.SetValues(PujaVM);

                    await _context.SaveChangesAsync();

                    return RedirectToPage("/Items/Details", new { id = Item.ID.ToString() });
                }
            }
            else
            {
                if (PujaVM.PujaMonto <= MaxPuja.PujaMonto)
                {
                    ModelState.AddModelError("Monto", $"Monto debe ser mas que {MaxPuja.PujaMonto}");

                    //return Page();
                    return RedirectToPage("./Create", new { id = Item.ID.ToString() });
                }
                else
                {
                    PujaVM.ItemID = Item.ID;
                    PujaVM.FechaPuesto = DateTime.Now;

                    var entry = _context.Add(new Puja());
                    entry.CurrentValues.SetValues(PujaVM);

                    await _context.SaveChangesAsync();

                    return RedirectToPage("/Items/Details", new { id = Item.ID.ToString() });
                }
            }
        }
    }

    public class PujaViewModel
    {
        [Required]
        [DisplayName("Nombre completo")]
        public string NombreCompleto { get; set; }

        public int ItemID { get; set; }

        [Required]
        [DisplayName("Cedula")]
        public string Cedula { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Entre numero valido")]
        [DisplayName("Monto de puja")]
        public float PujaMonto { get; set; }

        public DateTime FechaPuesto { get; set; }
    }
}
