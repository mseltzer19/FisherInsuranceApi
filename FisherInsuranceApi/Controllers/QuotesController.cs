using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/quotes")] 
    public class QuotesController : Controller 
    { 
        //private IMemoryStore db;
        private readonly FisherContext db;
        /*public QuotesController(IMemoryStore repo)
        {
            db = repo;
        } */
        public QuotesController(FisherContext context) 
        { 
           db = context; 
        }
        // POST api/auto/quotes 
        /*[HttpPost] 
        public IActionResult Post([FromBody] Quote quote) 
        { 
            return Ok(db.CreateQuote(quote)); 
        }*/
          [HttpPost] 
        public IActionResult Post([FromBody] Quote quote) 
        { 
            var newQuote = db.Quotes.Add(quote); 
            db.SaveChanges(); 
 
            return CreatedAtRoute("GetQuote", new { id = quote.Id }, quote); 
        } 
/*

         // GET api/auto/quotes/5 
        [HttpGet("{id}")] 
        public IActionResult Get(int id) 
        { 
            return Ok(db.RetrieveQuote(id));  
        }*/
         [HttpGet("{id}", Name = "GetQuote")] 
        public IActionResult Get(int id) 
        { 
            return Ok(db.Quotes.Find(id)); 
        } 
        /*

          // PUT api/auto/quotes/id 
        [HttpPut("{id}")] 
        public IActionResult Put(int id, [FromBody] Quote quote) 
        { 
            return Ok(db.UpdateQuote(quote));  
        } */
        [HttpPut("{id}")] 
        public IActionResult Put(int id, [FromBody] Quote quote) 
        { 
            var newQuote = db.Quotes.Find(id); 
            if (newQuote == null) 
            { 
                return NotFound(); 
            } 
            newQuote = quote; 
            db.SaveChanges(); 
            return Ok(newQuote); 
        }
        /*

         // DELETE api/auto/quotes/id 
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        { 
            db.DeleteQuote(id);
            return Ok();  
        }*/
          [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        { 
            var quoteToDelete = db.Quotes.Find(id); 
            if (quoteToDelete == null) 
            { 
                return NotFound(); 
            } 
 
            db.Quotes.Remove(quoteToDelete); 
            db.SaveChangesAsync(); 
 
            return NoContent(); 
 
        }
        /*

        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.RetrieveAllQuotes);
        } */
         [HttpGet] 
        public IActionResult GetQuotess() 
        { 
            return Ok(db.Quotes); 
        }
    }