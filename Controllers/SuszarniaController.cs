using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Controllers
{
    public class SuszarniaController : Controller
    {
        private readonly SuszarniaContext _context;
        private readonly IConfiguration _configuration;

        public SuszarniaController(SuszarniaContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index(string searchNm, string searchMaterial, string searchName, string searchColor)
        {
            tmpTraceData tmpData = new tmpTraceData(_configuration);
            TraceabilityLists traceabilityCarts = new TraceabilityLists();

            traceabilityCarts.Suszarnia = tmpData.GetSuszarniaCarts();

            var suszarnia = from k in traceabilityCarts.Suszarnia select k;

            if (!String.IsNullOrEmpty(searchNm))
                suszarnia = suszarnia.Where(k => k.Nm.Contains(searchNm));
            if (!String.IsNullOrEmpty(searchMaterial))
                suszarnia = suszarnia.Where(k => k.Material.Contains(searchMaterial));
            if (!String.IsNullOrEmpty(searchName))
                suszarnia = suszarnia.Where(k => k.Nr_wozka.Contains(searchName));
            if (!String.IsNullOrEmpty(searchColor))
                suszarnia = suszarnia.Where(k => k.Kolor_cewki.Contains(searchColor));

            traceabilityCarts.Suszarnia = suszarnia.ToList();

            return View(traceabilityCarts);
        }

        public IActionResult Edit(int? id)
        {
            Suszarnia suszarniaCart = new Suszarnia();
            if (id > 0)
            {
                suszarniaCart = FindCartByID(id);
            }
            return View(suszarniaCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,Suszenie1,TS_SUSZ1")] Suszarnia suszarnia)
        {
            if (id != suszarnia.ID_Trace)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(suszarnia);
        }

        public IActionResult Delete(int? id)
        {
            Suszarnia suszarniaCart = FindCartByID(id);

            return View(suszarniaCart);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using(SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("ResetCartByID", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ID_Trace", id);
                sqlCommand.ExecuteNonQuery();
            }

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public Suszarnia FindCartByID(int? ID_Trace)
        {
            Suszarnia suszarniaCart = new Suszarnia();
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
                    suszarniaCart.ID_Trace = Convert.ToInt32(dt.Rows[0]["ID_Trace"].ToString());
                    suszarniaCart.Nr_wozka = dt.Rows[0]["Nr_wozka"].ToString();
                    suszarniaCart.Material = dt.Rows[0]["Material"].ToString();
                    suszarniaCart.Nm = dt.Rows[0]["Nm"].ToString();
                    suszarniaCart.Typ_cewki = dt.Rows[0]["Typ_cewki"].ToString();
                    suszarniaCart.Kolor_cewki = dt.Rows[0]["Kolor_cewki"].ToString();
                    suszarniaCart.Suszenie1 = dt.Rows[0]["Suszenie1"].ToString();
                    suszarniaCart.TS_SUSZ1 = Convert.ToDateTime(dt.Rows[0]["TS_SUSZ1"]);
                }
                return suszarniaCart;
            }
        }

/*        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {

            return RedirectToAction(nameof(Edit));
        }
*/
        /*        // GET: Suszarnia
                public async Task<IActionResult> Index()
                {
                    return View(await _context.Suszarnia.ToListAsync());
                }

                // GET: Suszarnia/Details/5
                public async Task<IActionResult> Details(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var suszarnia = await _context.Suszarnia
                        .FirstOrDefaultAsync(m => m.ID_Trace == id);
                    if (suszarnia == null)
                    {
                        return NotFound();
                    }

                    return View(suszarnia);
                }

                // GET: Suszarnia/Create
                public IActionResult Create()
                {
                    return View();
                }

                // POST: Suszarnia/Create
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,Suszenie1,TS_SUSZ1")] Suszarnia suszarnia)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(suszarnia);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(suszarnia);
                }

                // GET: Suszarnia/Edit/5
                public async Task<IActionResult> Edit(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var suszarnia = await _context.Suszarnia.FindAsync(id);
                    if (suszarnia == null)
                    {
                        return NotFound();
                    }
                    return View(suszarnia);
                }

                // POST: Suszarnia/Edit/5
                // To protect from overposting attacks, enable the specific properties you want to bind to.
                // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Edit(int id, [Bind("ID_Trace,Nr_wozka,Nm,Material,Typ_cewki,Kolor_cewki,Suszenie1,TS_SUSZ1")] Suszarnia suszarnia)
                {
                    if (id != suszarnia.ID_Trace)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(suszarnia);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!SuszarniaExists(suszarnia.ID_Trace))
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
                    return View(suszarnia);
                }

                // GET: Suszarnia/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var suszarnia = await _context.Suszarnia
                        .FirstOrDefaultAsync(m => m.ID_Trace == id);
                    if (suszarnia == null)
                    {
                        return NotFound();
                    }

                    return View(suszarnia);
                }

                // POST: Suszarnia/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var suszarnia = await _context.Suszarnia.FindAsync(id);
                    _context.Suszarnia.Remove(suszarnia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool SuszarniaExists(int id)
                {
                    return _context.Suszarnia.Any(e => e.ID_Trace == id);
                }*/
    }
}
