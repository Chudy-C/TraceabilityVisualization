using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace TraceabilityVisualization_v2.Models.Visualization
{
    public class TmpVisualData
    {
        private readonly IConfiguration _configuration;

        public TmpVisualData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CountCartsWithPW> getCartsWithPW()
        {
            List<CountCartsWithPW> listCountCartsWithPW = new List<CountCartsWithPW>();

            DataTable dt = new DataTable();
            using(SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("VisualizationWithPW", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }
            for (int i = 0; i< dt.Rows.Count ; i++)
            {
                CountCartsWithPW _cartWithPW = new CountCartsWithPW();
                _cartWithPW.asortyment = dt.Rows[i]["Asortyment"].ToString();
                _cartWithPW.przedzalnia = dt.Rows[i]["Przedzalnia"].ToString();
                _cartWithPW.suszarnia = dt.Rows[i]["Suszarnia"].ToString();
                _cartWithPW.komora = dt.Rows[i]["Komora"].ToString();
                _cartWithPW.przewijalnia = dt.Rows[i]["Przewijalnia"].ToString();
                _cartWithPW.suma = dt.Rows[i]["SUMA"].ToString();

                listCountCartsWithPW.Add(_cartWithPW);
            }

            object sumaPrzedzalniaCol = dt.Compute("Sum(Przedzalnia)", string.Empty);
            object sumaSuszarniaCol = dt.Compute("Sum(Suszarnia)", string.Empty);
            object sumaKomoraCol = dt.Compute("Sum(Komora)", string.Empty);
            object sumaPrzewijalniaCol = dt.Compute("Sum(Przewijalnia)", string.Empty);
            object sumaSumaCol = dt.Compute("Sum(SUMA)", string.Empty);

            DataRow _sumaDzial = dt.NewRow();
            _sumaDzial["Asortyment"] = "SUMA";
            _sumaDzial["Przedzalnia"] = sumaPrzedzalniaCol;
            _sumaDzial["Suszarnia"] = sumaSuszarniaCol;
            _sumaDzial["Komora"] = sumaKomoraCol;
            _sumaDzial["Przewijalnia"] = sumaPrzewijalniaCol;
            _sumaDzial["SUMA"] = sumaSumaCol;
            dt.Rows.Add(_sumaDzial);

            CountCartsWithPW _sumaCart = new CountCartsWithPW();
            _sumaCart.asortyment = "SUMA";
            _sumaCart.przedzalnia = sumaPrzedzalniaCol.ToString();
            _sumaCart.suszarnia = sumaSuszarniaCol.ToString();
            _sumaCart.komora = sumaKomoraCol.ToString();
            _sumaCart.przewijalnia = sumaPrzewijalniaCol.ToString();
            _sumaCart.suma = sumaSumaCol.ToString();

            listCountCartsWithPW.Add(_sumaCart);

            return listCountCartsWithPW;
        }

        public List<CountCartsWithoutPW> getCartsWithoutPW()
        {
            List<CountCartsWithoutPW> listCountCartsWithoutPW = new List<CountCartsWithoutPW>();

            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("VisualizationWithoutPW", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CountCartsWithoutPW _cartWithoutPW = new CountCartsWithoutPW();
                _cartWithoutPW.asortyment = dt.Rows[i]["Asortyment"].ToString();
                _cartWithoutPW.przedzalnia = dt.Rows[i]["Przedzalnia"].ToString();
                _cartWithoutPW.suszarnia = dt.Rows[i]["Suszarnia"].ToString();
                _cartWithoutPW.komora = dt.Rows[i]["Komora"].ToString();
                _cartWithoutPW.suma = dt.Rows[i]["SUMA"].ToString();

                listCountCartsWithoutPW.Add(_cartWithoutPW);
            }

            object sumaPrzedzalniaCol = dt.Compute("Sum(Przedzalnia)", string.Empty);
            object sumaSuszarniaCol = dt.Compute("Sum(Suszarnia)", string.Empty);
            object sumaKomoraCol = dt.Compute("Sum(Komora)", string.Empty);
            object sumaSumaCol = dt.Compute("Sum(SUMA)", string.Empty);

            CountCartsWithoutPW _sumaCart = new CountCartsWithoutPW();
            _sumaCart.asortyment = "SUMA";
            _sumaCart.przedzalnia = sumaPrzedzalniaCol.ToString();
            _sumaCart.suszarnia = sumaSuszarniaCol.ToString();
            _sumaCart.komora = sumaKomoraCol.ToString();
            _sumaCart.suma = sumaSumaCol.ToString();

            listCountCartsWithoutPW.Add(_sumaCart);

            return listCountCartsWithoutPW;
        }

        public EmptyCart getEmptyCartsCounter()
        {
            List<EmptyCart> _emptyCartsCounter = new List<EmptyCart>();
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("VisualizationEmptyCarts", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmptyCart emptyCart = new EmptyCart();
                emptyCart.emptyCartsCounter = dt.Rows[i]["PusteWozki"].ToString();

                _emptyCartsCounter.Add(emptyCart);
            }

            return _emptyCartsCounter.First();
        }
    }
}
