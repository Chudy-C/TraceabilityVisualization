using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TraceabilityVisualization_v2.Models.AsortymentVisualization
{
    public class temporaryData
    {
        private readonly IConfiguration _configuration;

        public temporaryData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<AllMaterials> getAllMaterials()
        {
            List<AllMaterials> _allMaterialsList = new List<AllMaterials>();


            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("CountCartsGroupByMaterial", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                AllMaterials _asortyment = new AllMaterials();
                _asortyment.Material = dataTable.Rows[i]["Asortyment"].ToString();
                _allMaterialsList.Add(_asortyment);
            }

            return _allMaterialsList;
        }

        public List<SuszarniaAsortyment> getSuszarniaList()
        {
            List<SuszarniaAsortyment> _suszarniaList = new List<SuszarniaAsortyment>();


            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("CountCartsGroupByMaterial", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
            }
            
            for (int i =0; i< dataTable.Rows.Count; i++)
            {
                SuszarniaAsortyment _suszarniaAsortyment = new SuszarniaAsortyment();
                _suszarniaAsortyment.Material = dataTable.Rows[i]["Suszarnia"].ToString();
                _suszarniaList.Add(_suszarniaAsortyment);
            }

            return _suszarniaList;
        }
        public List<KomoraAsortyment> getKomoraList()
        {
            List<KomoraAsortyment> _komoraList = new List<KomoraAsortyment>();

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("CountCartsGroupByMaterial", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                KomoraAsortyment _komoraAsortyment = new KomoraAsortyment();
                _komoraAsortyment.Material = dataTable.Rows[i]["Komora"].ToString();
                _komoraList.Add(_komoraAsortyment);
            }
            return _komoraList;
        }
        public List<PrzewijalniaAsortyment> getPrzewijalniaList()
        {
            List<PrzewijalniaAsortyment> _przewijalniaList = new List<PrzewijalniaAsortyment>();

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("connectionString")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("CountCartsGroupByMaterial", sqlConnection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                PrzewijalniaAsortyment _przewijalniaAsortyment = new PrzewijalniaAsortyment();
                _przewijalniaAsortyment.Material = dataTable.Rows[i]["Przewijalnia"].ToString();
                _przewijalniaList.Add(_przewijalniaAsortyment);
            }
            return _przewijalniaList;
        }

    }
}
