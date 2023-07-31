using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using UserFeedback;
using UserFeedback.models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

[Route("api/[controller]")]
[ApiController]

public class FeedbackController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public FeedbackController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public JsonResult PostFeedback(Feedback fed)
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
            return new JsonResult("Added Successfully");
        }
    [HttpGet]
    public JsonResult GetFeedback()
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
    [HttpDelete]
    [Route("DeleteFeedback")]
    public JsonResult DeleteFeedback(int id)
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
        return new JsonResult("Deleted Successfully");
    }

}
