#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SatStackerWeb.DAL;
using SatStackerWeb.Models;

namespace SatStackerWeb.Pages.Transaction
{
    public class EditModel : PageModel
    {
        private readonly SatStackerWeb.DAL.SatStackerContext _context;

        public EditModel(SatStackerWeb.DAL.SatStackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EntityTransaction EntityTransaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EntityTransaction = await _context.Transactions.FirstOrDefaultAsync(m => m.EntityTransactionId == id);

            if (EntityTransaction == null)
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

            _context.Attach(EntityTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityTransactionExists(EntityTransaction.EntityTransactionId))
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

        private bool EntityTransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.EntityTransactionId == id);
        }
    }
}
