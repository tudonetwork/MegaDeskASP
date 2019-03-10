using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk.Models;

namespace MegaDesk.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk.Models.MegaDeskContext _context;

        public CreateModel(MegaDesk.Models.MegaDeskContext context)
        {
            _context = context;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; }

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

            // Get Date Now 2019-01-01 00:00:00
            Quote.Date = DateTime.Now;

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = Quote.ID });


        }
    }
}