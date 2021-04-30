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
using TraceabilityVisualization_v2.Models;

namespace TraceabilityVisualization_v2.Controllers
{
    public class KomoraController : Controller
    {
        //private readonly KomoraContext _context;
        private readonly IConfiguration _configuration;
/*        public KomoraController(KomoraContext context)
        {
            _context = context;
        }*/
        public KomoraController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Komora
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("CountCartsGroupByMaterial", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
            }

            //stworzyć dwa modele oraz listy dwóch zapytań sql 
            // spiąć w jedną klasę oraz wyświetlić jeden dla lewej strony, drugi dla prawej

            object sumaSuszarniaCol = dataTable.Compute("Sum(Suszarnia)", string.Empty);
            object sumaKomoraCol = dataTable.Compute("Sum(Komora)", string.Empty);
            object sumaPrzewijalniaCol = dataTable.Compute("Sum(Przewijalnia)", string.Empty);
            object sumaSumaCol = dataTable.Compute("Sum(SUMA)", string.Empty);

            DataRow _sumaDzial = dataTable.NewRow();
            _sumaDzial["Asortyment"] = "SUMA";
            _sumaDzial["Suszarnia"] = sumaSuszarniaCol;
            _sumaDzial["Komora"] = sumaKomoraCol;
            _sumaDzial["Przewijalnia"] = sumaPrzewijalniaCol;
            _sumaDzial["SUMA"] = sumaSumaCol;
            dataTable.Rows.Add(_sumaDzial);

/*            DataTable tmpTable = new DataTable();
            tmpTable.Clear();
            tmpTable.Columns.Add("Asortyment");
            tmpTable.Columns.Add("Suszarnia");
            tmpTable.Columns.Add("Komora");
            tmpTable.Columns.Add("SUMA");

            foreach (DataRow row in dataTable.Rows)
            {
                object valuePW = row["Przewijalnia"];
                if (valuePW == DBNull.Value)
                {
                    tmpTable.ImportRow(row);
                }
            }

            object suszarniaNotNull = tmpTable.Compute("Sum(Suszarnia)", string.Empty);
            object komoraNotNull = tmpTable.Compute("Sum(Komora)", string.Empty);
            object sumaNotNull = tmpTable.Compute("Sum(SUMA)", string.Empty);

            DataRow _notNullValues = dataTable.NewRow();
            _notNullValues["Asortyment"] = "SUMA";
            _notNullValues["Suszarnia"] = suszarniaNotNull;
            _notNullValues["Komora"] = komoraNotNull;
            _notNullValues["SUMA"] = sumaNotNull;

            dataTable.Rows.Add(_notNullValues);*/

            return View(dataTable);
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

        // GET: Komora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komora = await _context.Komora.FindAsync(id);
            if (komora == null)
            {
                return NotFound();
            }
            return View(komora);
        }

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
