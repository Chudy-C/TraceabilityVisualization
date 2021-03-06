using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Controllers
{
    public class KomoraController : Controller
    {
        private readonly KomoraContext _context;
        private readonly IConfiguration _configuration;
        public KomoraController(KomoraContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Komora
        public IActionResult Index(string searchNm, string searchMaterial, string searchName, string searchColor)
        {

            tmpTraceData tmpData = new tmpTraceData(_configuration);
            TraceabilityLists traceabilityCarts = new TraceabilityLists();

            traceabilityCarts.Komora = tmpData.getKomoraCarts();

            var komora = from k in traceabilityCarts.Komora select k;

            if (!String.IsNullOrEmpty(searchNm))
                komora = komora.Where(k => k.Nm.Contains(searchNm));
            if (!String.IsNullOrEmpty(searchMaterial))
                komora = komora.Where(k => k.Material.Contains(searchMaterial));
            if (!String.IsNullOrEmpty(searchName))
                komora = komora.Where(k => k.Nr_wozka.Contains(searchName));
            if (!String.IsNullOrEmpty(searchColor))
                komora = komora.Where(k => k.Kolor_cewki.Contains(searchColor));

            traceabilityCarts.Komora = komora.ToList();

            return View(traceabilityCarts);
        }

        public IActionResult Edit(int? id)
        {
            Komora komoraCart = new Komora();
            if (id>0)
            {
                komoraCart = FindCartByID(id);
            }
            return View(komoraCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,TS_KOM1")] Komora komora)
        {
            if (id != komora.ID_Trace)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(komora);
        }

        [NonAction]
        public Komora FindCartByID(int? ID_Trace)
        {
            Komora komoraCart = new Komora();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                DataTable dt = new DataTable();
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("GetTraceCartByID", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@ID_Trace", ID_Trace);
                sqlAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    komoraCart.ID_Trace = Convert.ToInt32(dt.Rows[0]["ID_Trace"].ToString());
                    komoraCart.Nr_wozka = dt.Rows[0]["Nr_wozka"].ToString();
                    komoraCart.Material = dt.Rows[0]["Material"].ToString();
                    komoraCart.Nm = dt.Rows[0]["Nm"].ToString();
                    komoraCart.Typ_cewki = dt.Rows[0]["Typ_cewki"].ToString();
                    komoraCart.Kolor_cewki = dt.Rows[0]["Kolor_cewki"].ToString();
                    komoraCart.TS_KOM1 = Convert.ToDateTime(dt.Rows[0]["TS_KOM1"]);
                }
                return komoraCart;
            }
        }

        /*        // GET: Komora/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var komora = await _context.Komora
                        .FirstOrDefaultAsync(m => m.ID_Trace == id);
                    if (komora == null)
                    {
                        return NotFound();
                    }

                    return View(komora);
                }

                // GET: Komora/Create
                public IActionResult Create()
                {
                    return View();
                }

                // POST: Komora/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,TS_KOM1")] Komora komora)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(komora);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(komora);
                }
        */

        /*        // GET: Komora/Edit/5
                public async Task<IActionResult> Edit(string? nr_wozka)
                {
                    if (nr_wozka == null)
                    {
                        return NotFound();
                    }

                    var komora = await _context.Komora.FindAsync(nr_wozka);
                    if (komora == null)
                    {
                        return NotFound();
                    }
                    return View(komora);
                }
        */
        /*
                // POST: Komora/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,TS_KOM1")] Komora komora)
                {
                    if (id != komora.ID_Trace)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(komora);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!KomoraExists(komora.ID_Trace))
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
                    return View(komora);
                }

                // GET: Komora/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var komora = await _context.Komora
                        .FirstOrDefaultAsync(m => m.ID_Trace == id);
                    if (komora == null)
                    {
                        return NotFound();
                    }

                    return View(komora);
                }

                // POST: Komora/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var komora = await _context.Komora.FindAsync(id);
                    _context.Komora.Remove(komora);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool KomoraExists(int id)
                {
                    return _context.Komora.Any(e => e.ID_Trace == id);
                }*/
    }
}
