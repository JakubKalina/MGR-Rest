using System.Collections.Generic;
using mgrapi.Dtos.Category;
using mgrapi.Interfaces;
using mgrapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mgrapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
      _categoriesService = categoriesService;
    }

    [HttpGet("")]
    [Produces(typeof(GetAllCategoriesDto))]
    public IActionResult GetCategories()
    {
      var categories = _categoriesService.GetAll();

      return Ok(categories);
    }

    [HttpGet("{id:int}")]
    [Produces(typeof(GetCategoryByIdDto))]
    public IActionResult GetCategoryById([FromRoute] int id)
    {
      var category = _categoriesService.Get(id);

      if(category == null)
        return NotFound();

      return Ok(category);
    }

    [HttpPost("")]
    public IActionResult CreateCategory([FromBody] CreateCategoryDto category)
    {
      var id = _categoriesService.Create(category);

      return Created($"api/categories/{id}", id);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryDto category)
    {
      bool isUpdated = _categoriesService.Update(id, category);

      if (isUpdated)
        return NoContent();

      return NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategory([FromRoute] int id)
    {
      bool isDeleted = _categoriesService.Delete(id);

      if (isDeleted)
        return NoContent();

      return NotFound();
    }

  }
}