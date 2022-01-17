using Re_Frameworks_Exs_ForTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Re_Frameworks_Exs_ForTest.Controllers.api
{
    public class KidShoesController : ApiController
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=MyShoeStoreDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: api/KidShoes
        public KidShoesDCDataContext DataContext = new KidShoesDCDataContext(connString);
        public IHttpActionResult Get()
        {
            List<KidShoe> theList = DataContext.KidShoes.ToList();
            return Ok(new { theList });
        }

        // GET: api/KidShoes/5
        public IHttpActionResult Get(int id)
        {
            KidShoe theShoe = DataContext.KidShoes.First(item => item.Id == id);
            return Ok(new { theShoe });
        }

        // POST: api/KidShoes
        public IHttpActionResult Post([FromBody] KidShoe AddedShoe)
        {
            DataContext.KidShoes.InsertOnSubmit(AddedShoe);
            DataContext.SubmitChanges();

            return Ok(new { AddedShoe });
        }

        // PUT: api/KidShoes/5
        public IHttpActionResult Put(int id, [FromBody] KidShoe EditedShoe)
        {
            KidShoe ShoeToEdit = DataContext.KidShoes.First((item) => item.Id == id);
            ShoeToEdit.Company = EditedShoe.Company;
            ShoeToEdit.Material = EditedShoe.Material;
            ShoeToEdit.inStock = EditedShoe.inStock;
            ShoeToEdit.Price = EditedShoe.Price;
            ShoeToEdit.Size = EditedShoe.Size;
            DataContext.SubmitChanges();

            return Ok("Edited Very Well.");

        }

        // DELETE: api/KidShoes/5
        public IHttpActionResult Delete(int id)
        {
            KidShoe DeletedShoe = DataContext.KidShoes.First((item)=>item.Id == id);    
            DataContext.KidShoes.DeleteOnSubmit(DeletedShoe);
            DataContext.SubmitChanges();
            return Ok("Deleted Shoe.!");
        }
    }
}
