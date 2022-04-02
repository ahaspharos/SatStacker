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
    public class IndexModel : PageModel
    {
        private readonly SatStackerWeb.DAL.SatStackerContext _context;

        public IndexModel(SatStackerWeb.DAL.SatStackerContext context)
        {
            _context = context;
        }

        public IList<EntityTransaction> EntityTransaction { get;set; }

        public async Task OnGetAsync()
        {
            EntityTransaction = await _context.Transactions.ToListAsync();
        }
    }
}
