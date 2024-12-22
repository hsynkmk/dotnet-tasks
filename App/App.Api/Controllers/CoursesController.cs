using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // GET: api/<CoursesController>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_courseService.GetAll());
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
