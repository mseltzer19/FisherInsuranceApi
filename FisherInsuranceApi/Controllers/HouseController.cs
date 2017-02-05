using Microsoft.AspNetCore.Mvc;

[Route("api/house/quotes")] 
    public class HouseController : Controller 
    { 
        // POST api/house/quotes 
        [HttpPost] 
        public IActionResult Post([FromBody]string value) 
        { 
            return Created("", value); 
        }

         // GET api/house/quotes/5 
        [HttpGet("{id}")] 
        public IActionResult Get(int id) 
        { 
            return Ok("The id is: " + id); 
        }

          // PUT api/house/quotes/id 
        [HttpPut("{id}")] 
        public IActionResult Put(int id, [FromBody]string value) 
        { 
            return NoContent(); 
        } 

         // DELETE api/house/quotes/id 
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        { 
            return Delete(id); 
        }
    }