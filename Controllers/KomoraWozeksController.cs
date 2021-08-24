/*using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraceabilityVisualization.Data;
using TraceabilityVisualization.Models;

namespace TraceabilityVisualization.Controllers
{
    public class KomoraWozeksController : Controller
    {
        private readonly KomoraContext _context;
        private readonly IConfiguration _configuration;

        public KomoraWozeksController(KomoraContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        // GET: KomoraWozeks
        public async Task<IActionResult> Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("GetKomoraCartsVisualization", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);

            }
            return View(await _context.KomoraWozek.ToListAsync());
        }

        // GET: KomoraWozeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komoraWozek = await _context.KomoraWozek
                .FirstOrDefaultAsync(m => m.ID_Trace == id);
            if (komoraWozek == null)
            {
                return NotFound();
            }

            return View(komoraWozek);
        }

        // GET: KomoraWozeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomoraWozeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,TS_KOM1")] KomoraWozek komoraWozek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komoraWozek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komoraWozek);
        }

        // GET: KomoraWozeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komoraWozek = await _context.KomoraWozek.FindAsync(id);
            if (komoraWozek == null)
            {
                return NotFound();
            }
            return View(komoraWozek);
        }

        // POST: KomoraWozeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,TS_KOM1")] KomoraWozek komoraWozek)
        {
            if (id != komoraWozek.ID_Trace)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komoraWozek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomoraWozekExists(komoraWozek.ID_Trace))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(komoraWozek);
        }

        // GET: KomoraWozeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komoraWozek = await _context.KomoraWozek
                .FirstOrDefaultAsync(m => m.ID_Trace == id);
            if (komoraWozek == null)
            {
                return NotFound();
            }

            return View(komoraWozek);
        }

        // POST: KomoraWozeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komoraWozek = await _context.KomoraWozek.FindAsync(id);
            _context.KomoraWozek.Remove(komoraWozek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomoraWozekExists(int id)
        {
            return _context.KomoraWozek.Any(e => e.ID_Trace == id);
        }
    }
}
*/