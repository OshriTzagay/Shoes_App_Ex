using Re_Frameworks_Exs_ForTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Re_Frameworks_Exs_ForTest.Controllers.api
{
    public class SportShoesController : ApiController
    {
        public MyShoeStoreDBC DBC = new MyShoeStoreDBC();
        // GET: api/SportShoes
        public IHttpActionResult Get()
        {
            try
            {
                List<SportShoe> sportShoes = DBC.SportShoes.ToList();
                return Ok(new { sportShoes });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/SportShoes/5
        public async Task<IHttpActionResult> Get(int id)
        {
            SportShoe theChosenShoe = await DBC.SportShoes.FindAsync(id);
            return Ok(new { theChosenShoe });
        }

        // POST: api/SportShoes
        public async Task<IHttpActionResult> Post([FromBody] SportShoe value)
        {
            DBC.SportShoes.Add(value);
            await DBC.SaveChangesAsync();
            return Ok("Added Shoe To The Table .");
        }

        // PUT: api/SportShoes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] SportShoe value)
        {

            SportShoe EditedShoe = await DBC.SportShoes.FindAsync(id);
            EditedShoe.Id = value.Id;
            EditedShoe.ShoeCompany = value.ShoeCompany;
            EditedShoe.Brand = value.Brand;
            EditedShoe.Size = value.Size;
            EditedShoe.Price = value.Price;

            await DBC.SaveChangesAsync();

            return Ok($"Edited Shoe id :  {id} , Successfully ");

        }

        // DELETE: api/SportShoes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            SportShoe DeletedShoe = await DBC.SportShoes.FindAsync(id);
            DBC.SportShoes.Remove(DeletedShoe);
            await DBC.SaveChangesAsync();

            return Ok("DELETED SHOE !!");
        }
    }
}
