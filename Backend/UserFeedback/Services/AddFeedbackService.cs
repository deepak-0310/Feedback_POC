using System.Data;
using System.Data.SqlClient;
using UserFeedback.Interfaces;
using UserFeedback.models;

namespace UserFeedback.Services
{
    public class AddFeedbackService :IAddFeedbackService
    {
        private readonly IConfiguration _configuration;
        public AddFeedbackService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public void AddFeedback(Feedback fed)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DemoConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("spPostFeedback", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Name", fed.UserName);
                    myCommand.Parameters.AddWithValue("@Feedback", fed.UserFeedback);
                    myCommand.Parameters.AddWithValue("Date_Time", DateTime.Now);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
        }
    }
}
