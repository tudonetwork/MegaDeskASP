using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Models;

namespace MegaDesk.Pages.Quotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDesk.Models.MegaDeskContext _context;

        public EditModel(MegaDesk.Models.MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            //Instantiate DeskQuote and send the form information to it
            DeskQuote dq = new DeskQuote(Quote.Width, Quote.Depth, Quote.CountDrawer, Quote.SurfaceMaterial, Quote.BuildOption);

            //Get final quote
            var fprice = dq.CalcFinalQuote();
            Quote.FinalCost = fprice;

            _context.Attach(Quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(Quote.ID))
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

        private bool QuoteExists(int id)
        {
            return _context.Quote.Any(e => e.ID == id);
        }
    }
}
