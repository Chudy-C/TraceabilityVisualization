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
using TraceabilityVisualization_v2.Models.Visualization;

namespace TraceabilityVisualization_v2.Controllers
{
    public class VisualizationController : Controller
    {
        private readonly IConfiguration _configuration;

        public VisualizationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Asortyment()
        {
            TmpVisualData _tmpData = new TmpVisualData(_configuration);
            VisualizationLists visualizationLists = new VisualizationLists();

            visualizationLists.listWithPW = _tmpData.getCartsWithPW();
            visualizationLists.listWithoutPW = _tmpData.getCartsWithoutPW();
            /*            visualizationLists.listEmptyCartsCount = _tmpData.getEmptyCartsCounter();*/
            EmptyCart emptyCart = new EmptyCart();
            emptyCart = _tmpData.getEmptyCartsCounter();


            visualizationLists.emptyCartCounter = emptyCart.emptyCartsCounter;

            return View(visualizationLists);
        }
    }
}
