using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using UserFeedback.Interfaces;

namespace UserFeedback.Services
{
    public class GetFeedbackService :  IGetFeedbackService
    {
        private readonly IConfiguration _configuration;
        public GetFeedbackService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public JsonResult GetAllFeedbacks()
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DemoConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("spGetFeedback", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
