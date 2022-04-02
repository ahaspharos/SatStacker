#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SatStackerWeb.DAL;
using SatStackerWeb.Models;

namespace SatStackerWeb.Pages.Transaction
{
    public class DeleteModel : PageModel
    {
        private readonly SatStackerWeb.DAL.SatStackerContext _context;

        public DeleteModel(SatStackerWeb.DAL.SatStackerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EntityTransaction = await _context.Transactions.FindAsync(id);

            if (EntityTransaction != null)
            {
                _context.Transactions.Remove(EntityTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
