using BestCoffee.Models;
using BestCoffee.Options;
using Microsoft.AspNetCore.Mvc;

namespace BestCoffee.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : ControllerBase
{
    public CoffeeController() 
    {
    }

    [HttpGet]
public ActionResult<List<Coffee>> GetAll() =>
    CoffeeOption.GetAll();

    [HttpGet("{id}")]
public ActionResult<Coffee> Get(int id)
{
    var coffee = CoffeeOption.Get(id);

    if(coffee == null)
        return NotFound();

    return coffee;
}

   [HttpPost]
public IActionResult Create(Coffee coffee)
{    
       CoffeeOption.Add(coffee);
    return CreatedAtAction(nameof(Get), new { id = coffee.Id }, coffee);        
    // This code will save the pizza and return a result
}

 [HttpPut("{id}")]
public IActionResult Update(int id, Coffee coffee)
{
    if (id != coffee.Id)
        return BadRequest();
           
    var existingCoffee = CoffeeOption.Get(id);
    if(existingCoffee is null)
        return NotFound();
   
    CoffeeOption.Update(coffee);           
   
    return NoContent();
    // This code will update the pizza and return a result
}

    


 [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var coffee = CoffeeOption.Get(id);
   
    if (coffee is null)
        return NotFound();
       
    CoffeeOption.Delete(id);
   
    return NoContent();
     // This code will delete the pizza and return a result

}
   
}