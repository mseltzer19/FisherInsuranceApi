//using FisherInsuranceApi.Data;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/claims")]
public class ClaimsController : Controller
{
    private readonly FisherContext db;
    public ClaimsController(FisherContext context)
    {
        db = context;
    }

    //private IMemoryStore db;
    /*public ClaimsController(IMemoryStore repo)
    {
        db = repo;
    } */

    // POST api/claim 
    /* [HttpPost] 
     public IActionResult Post([FromBody] Claim claim) 
     { 
         return Ok(db.CreateClaim(claim)); 
     }*/
    [HttpPost]
    public IActionResult Post([FromBody] Claim claim)
    {
        var newClaim = db.Claims.Add(claim);
        db.SaveChanges();
        return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim);
    }

    /*
          // GET api/claim/5 
         [HttpGet("{id}")] 
         public IActionResult Get(int id) 
         { 
             return Ok(db.RetrieveClaim(id));  
         }*/
    [HttpGet]
    public IActionResult GetClaims()
    {
        return Ok(db.Claims);
    }
    [HttpGet("{id}", Name = "GetClaim")]
    public IActionResult Get(int id)
    {
        return Ok(db.Claims.Find(id));
    }

    /*  // PUT api/claim/id 
    [HttpPut("{id}")] 
    public IActionResult Put(int id, [FromBody] Claim claim) 
    { 
        return Ok(db.UpdateClaim(claim));  
    } */
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Claim claim)
    {
        var newClaim = db.Claims.Find(id);
        if (newClaim == null)
        {
            return NotFound();
        }
        newClaim = claim;
        db.SaveChanges();
        return Ok(newClaim);
    }
    /*

        // DELETE api/claim/id 
       [HttpDelete("{id}")] 
       public IActionResult Delete(int id) 
       { 
           db.DeleteClaim(id);
           return Ok();  
       }*/
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var claimToDelete = db.Claims.Find(id);
        if (claimToDelete == null)
        {
            return NotFound();
        }
        db.Claims.Remove(claimToDelete);
        db.SaveChangesAsync();
        return NoContent();
    }
        /*

               [HttpGet]
               public IActionResult GetClaim()
               {
                   return Ok(db.RetrieveAllClaims);
               } */
    }