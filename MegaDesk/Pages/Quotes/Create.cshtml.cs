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

            //set up the list of surface materials from an enum per week 4 assignment. 
            List<Quote.SurfaceMaterials> listMaterials = Enum.GetValues(typeof(Quote.SurfaceMaterials)).Cast<Quote.SurfaceMaterials>().ToList();

            //cmbMaterial.DataSource = listMaterials;

            //set up building options for drop down menu
            //cmbBuildOption.DataSource = DeskQuote.BuildingOptionsList;


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
            DeskQuote dq = new DeskQuote(width, depth, countDrawer, material, buildOption, customerName);

            //Get final quote
            dq.CalcFinalQuote();

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();


            return  RedirectToPage("Details", new { id = DeskQuote.ID });

        }
    }
}