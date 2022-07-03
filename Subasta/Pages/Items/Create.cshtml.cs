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

namespace Subasta.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly Subasta.Data.SubastaContext _context;

        public CreateModel(Subasta.Data.SubastaContext context)
        {
            _context = context;
        }


        [BindProperty]
        public ItemVM ItemVm { get; set; } 

        public void OnGet()
        {
        }   

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Item == null || ItemVm == null)
            {
                return Page();
            }

            ItemVm.FechaPuesto = DateTime.Now;

            var entry = _context.Add(new Item());
            entry.CurrentValues.SetValues(ItemVm);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    public class ItemVM
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string ItemNombre { get; set; }

        [Required]
        [DisplayName("Precio Inicial")]
        public float PrecioInicial { get; set; }


        public DateTime FechaPuesto { get; set; }
    }
}
