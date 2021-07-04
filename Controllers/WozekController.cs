using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Controllers
{
    public class WozekController : Controller
    {
        private readonly WozekContext _context;
        private readonly IConfiguration _configuration;

        public WozekController(IConfiguration configuration,WozekContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: Wozek
        public IActionResult Index()
        {
            tmpTraceData tmpData = new tmpTraceData(_configuration);
            TraceabilityLists traceabilityList = new TraceabilityLists();

            traceabilityList.Wozek = tmpData.getWozekCarts();

            return View(traceabilityList.Wozek);
        }

        /*

                // GET: Wozek/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var wozek = await _context.Wozek
                        .FirstOrDefaultAsync(m => m.ID_Wozka == id);
                    if (wozek == null)
                    {
                        return NotFound();
                    }

                    return View(wozek);
                }

                // GET: Wozek/Create
                public IActionResult Create()
                {
                    return View();
                }

                // POST: Wozek/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("ID_Wozka,Nr_wozka,Waga_kg,Lokalizacja")] Wozek wozek)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(wozek);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(wozek);
                }

                // GET: Wozek/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var wozek = await _context.Wozek.FindAsync(id);
                    if (wozek == null)
                    {
                        return NotFound();
                    }
                    return View(wozek);
                }

                // POST: Wozek/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("ID_Wozka,Nr_wozka,Waga_kg,Lokalizacja")] Wozek wozek)
                {
                    if (id != wozek.ID_Wozka)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(wozek);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!WozekExists(wozek.ID_Wozka))
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
                    return View(wozek);
                }

                // GET: Wozek/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var wozek = await _context.Wozek
                        .FirstOrDefaultAsync(m => m.ID_Wozka == id);
                    if (wozek == null)
                    {
                        return NotFound();
                    }

                    return View(wozek);
                }

                // POST: Wozek/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var wozek = await _context.Wozek.FindAsync(id);
                    _context.Wozek.Remove(wozek);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool WozekExists(int id)
                {
                    return _context.Wozek.Any(e => e.ID_Wozka == id);
                }*/
    }
}
