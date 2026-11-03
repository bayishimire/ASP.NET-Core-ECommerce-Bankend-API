using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_ECommerce_API.Models;
using ASP.NET_Core_ECommerce_API.Data;
using ASP.NET_Core_ECommerce_API.DTOs;

namespace ASP.NET_Core_ECommerce_API.Controllers;

using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_ECommerce_API.Models;


[ApiController]
[Route("api/[controller]")]


public class Productscontroller : ControllerBase
{
    //difnine data fields
    public readonly AppDbContext _Products;
    //difine constructor

    public Productscontroller(AppDbContext context)
    {
        _Products = context;
    }



    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     var data = await _Products.Products
    //         .Include(item => item.Category).ToListAsync();
    //     {
    //         if (data == null)
    //         {
    //             return NotFound("No Products Found");
    //
    //         }
    //
    //         return Ok(data);
    //     }
    // }

    [HttpGet("Sort")]
    public async Task<IActionResult> Sort()
    {
        var sorts = await _Products.Products.Include(c => c.Category).OrderBy(items => items.ProductId).ToListAsync();
        {
            if (sorts == null)
            {
                return NotFound("No Products Found");
            }
        }
        return Ok(sorts);
    }




    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _Products.Products
            .AsNoTracking()
            .Select(p => new ProductResponseDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId,

                // Get category name through the relationship
                CategoryName = p.Category != null
                    ? p.Category.CategoryName
                    : null,

                CreatedAt = p.CreatedAt
            })
            .ToListAsync();

        if (products.Count == 0)
        {
            return NotFound("No products found.");
        }

        return Ok(products);
    }
}

        

