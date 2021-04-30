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
using TraceabilityVisualization_v2.Models.AsortymentVisualization;

namespace TraceabilityVisualization_v2.Controllers
{
    public class AsortymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public AsortymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            temporaryData _tmpData = new temporaryData(_configuration);
            Asortyment asortyment = new Asortyment();

            asortyment.allMaterialAsortmentList = _tmpData.getAllMaterials();
            asortyment.suszarniaAsortymentList = _tmpData.getSuszarniaList();
            asortyment.komoraAsortymentList = _tmpData.getKomoraList();
            asortyment.przewijalniaAsortymentList = _tmpData.getPrzewijalniaList();

            /*asortyment.allMaterialAsortmentList*/

            return View(asortyment);
        }
    }
}
