using ASP.NET_Core_ECommerce_API.Data;
using ASP.NET_Core_ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_ECommerce_API.Controllers;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[controller]")]


public class CategoriesController: ControllerBase
{
    //data fileds
    public readonly AppDbContext _Categories;
    //constructors
    public CategoriesController(AppDbContext context)
    {
        _Categories = context;
    }

    [HttpGet]
    public async Task<IActionResult> get_Categories()
    {
        var Categories_ = await _Categories.Categories.ToListAsync();
        {
            if (Categories_.Count == 0)
            {
                return NotFound("the re are no categories");
            }

            return Ok(Categories_);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> get_Categories(int id)
    {
        var category_id=await _Categories.Categories
            .Include(p=>p.Products).FirstOrDefaultAsync(c=>c.CategoryId==id);
        {
            if (category_id == null)
            {
                return NotFound("the re are no categories");
            }
            return Ok(category_id);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post_Categories([FromBody] Categories _new_post_categories)
    {
        if (_new_post_categories == null)
        {
            return NoContent();
        }

        await _Categories.Categories.AddRangeAsync(_new_post_categories);
        await _Categories.SaveChangesAsync();
        return Ok(_new_post_categories);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete_Categories(int id)
    {
        if (id <= 0)
        {
            return NotFound("The id is 0");
        }
        
        var delete_catg=await _Categories.Categories.FirstOrDefaultAsync(c=>c.CategoryId==id);
        {
            if (delete_catg == null)
            {
                return BadRequest($"the re are no categories found{id}");
            }

            _Categories.Categories.Remove(delete_catg);
            await _Categories.SaveChangesAsync();
            return Ok($"The successfully deleted {id}");
        }
    }

}
