using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    // GET: api/<CoursesController>
    [HttpGet]
    public IActionResult Get()
    {
        var 

    }

    // GET api/<CoursesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CoursesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CoursesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CoursesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
