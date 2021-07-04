using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraceabilityVisualization_v2.Models.Traceability;

namespace TraceabilityVisualization_v2.Models.Traceability
{
    public class tmpTraceData
    {
        private readonly IConfiguration _configuration;

        public tmpTraceData(IConfiguration configuration)
        {
            _configuration = configuration;    
        }

        public List<Komora> getKomoraCarts()
        {
            List<Komora> komoraCarts = new List<Komora>();

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("GetKomoraCartForm", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Komora komoraCart = new Komora();
                komoraCart.ID_Trace = Convert.ToInt32(dt.Rows[i]["ID_Trace"]);
                komoraCart.Nr_wozka = dt.Rows[i]["Nr_wozka"].ToString();
                komoraCart.Material = dt.Rows[i]["Material"].ToString();
                komoraCart.Nm = dt.Rows[i]["Nm"].ToString();
                komoraCart.Typ_cewki = dt.Rows[i]["Typ_cewki"].ToString();
                komoraCart.Kolor_cewki = dt.Rows[i]["Kolor_cewki"].ToString();
                komoraCart.TS_KOM1 = Convert.ToDateTime(dt.Rows[i]["TS_KOM1"]);

                komoraCarts.Add(komoraCart);
            }
            return komoraCarts;
        }


        public List<Wozek> getWozekCarts()
        {
            List<Wozek> emptyCarts = new List<Wozek>();

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("GetTblWozekData", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Wozek emptyCart = new Wozek();
                emptyCart.ID_Wozka = Convert.ToInt32(dt.Rows[i]["ID_Wozka"]);
                emptyCart.Nr_wozka = dt.Rows[i]["Nr_wozka"].ToString();
                emptyCart.Waga_kg = dt.Rows[i]["Waga_kg"].ToString();
                emptyCart.Lokalizacja = dt.Rows[i]["Lokalizacja"].ToString();

                emptyCarts.Add(emptyCart);
            }
            return emptyCarts;
        }

        public List<Suszarnia> GetSuszarniaCarts()
        {
            List<Suszarnia> suszarniaCarts = new List<Suszarnia>();

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("GetSuszarniaCartForm", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Suszarnia suszarniaCart = new Suszarnia();
                suszarniaCart.ID_Trace = Convert.ToInt32(dt.Rows[i]["ID_Trace"]);
                suszarniaCart.Nr_wozka = dt.Rows[i]["Nr_wozka"].ToString();
                suszarniaCart.Material = dt.Rows[i]["Material"].ToString();
                suszarniaCart.Nm = dt.Rows[i]["Nm"].ToString();
                suszarniaCart.Typ_cewki = dt.Rows[i]["Typ_cewki"].ToString();
                suszarniaCart.Kolor_cewki = dt.Rows[i]["Kolor_cewki"].ToString();
                suszarniaCart.Suszenie1 = dt.Rows[i]["Suszenie1"].ToString();
                suszarniaCart.TS_SUSZ1 = Convert.ToDateTime(dt.Rows[i]["TS_SUSZ1"]);

                suszarniaCarts.Add(suszarniaCart);
            }
            return suszarniaCarts;
        }


    }
}
