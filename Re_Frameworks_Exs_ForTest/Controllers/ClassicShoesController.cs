using Re_Frameworks_Exs_ForTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Re_Frameworks_Exs_ForTest.Controllers
{
    public class ClassicShoesController : ApiController
    {
        public static List<ClassicShoe> theList = new List<ClassicShoe>();
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=MyShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: api/ClassicShoes
        public IHttpActionResult Get()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = $@"SELECT * FROM ClassicShoes";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassicShoe theShoe = new ClassicShoe(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetBoolean(4), reader.GetInt32(5));
                        theList.Add(theShoe);
                        return Ok(new { theList });
                    }
                }
                connection.Close();
            }
            return BadRequest("Try Again.");
        }

        // GET: api/ClassicShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM ClassicShoes WHERE Id = {id}";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader DataReader = cmd.ExecuteReader();

                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            ClassicShoe chosenShoe = new ClassicShoe(DataReader.GetInt32(0), DataReader.GetString(1), DataReader.GetString(2), DataReader.GetBoolean(3), DataReader.GetBoolean(4), DataReader.GetInt32(5));
                            return Ok(new { chosenShoe });
                        }
                    }
                    connection.Close();
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/ClassicShoes
        public IHttpActionResult Post([FromBody] ClassicShoe value)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.Open();
                    string query = $@"INSERT INTO ClassicShoes VALUES('{value.Company}','{value.Gender}','{value.IsHeels}','{value.InStock}',{value.Size})";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader DataReader = cmd.ExecuteReader();
                    connection.Close();
                    return Ok("ADDED Successfully");
                }
            }
            catch (Exception)
            {
                return BadRequest("TryAgain.");
            }

        }

        // PUT: api/ClassicShoes/5
        public IHttpActionResult Put(int id, [FromBody] ClassicShoe value)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                string query = $@"UPDATE ClassicShoes SET Company = '{value.Company}',Gender = '{value.Gender}',IsHeels ='{value.IsHeels}', InStock ='{value.InStock}', Size= {value.Size} WHERE Id ={id}";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader DATA = cmd.ExecuteReader();

                connection.Close();
                return Ok("Edited Properly.");
            }
        }

        // DELETE: api/ClassicShoes/5
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = $@"DELETE FROM ClassicShoes WHERE Id = {id}";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader DATA = cmd.ExecuteReader();

                connection.Close();
                return Ok("Deleted Properly.");
            }
        }
    }
}
