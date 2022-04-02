#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SatStackerWeb.DAL;
using SatStackerWeb.Models;

namespace SatStackerWeb.Pages.Transaction
{
    public class CreateModel : PageModel
    {
        private readonly SatStackerWeb.DAL.SatStackerContext _context;

        public CreateModel(SatStackerWeb.DAL.SatStackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EntityTransaction EntityTransaction { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transactions.Add(EntityTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
