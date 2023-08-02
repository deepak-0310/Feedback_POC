using System.Data;
using System.Data.SqlClient;
using UserFeedback.Interfaces;

namespace UserFeedback.Services
{
    public class DeleteFeedbackService : IDeleteFeedbackService
    {
        private readonly IConfiguration _configuration;
        public DeleteFeedbackService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public void DeleteFeedback(int id)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DemoConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("spDeleteFeedback", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
        }
    }
}
