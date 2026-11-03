using ASP.NET_Core_ECommerce_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASP.NET_Core_ECommerce_API.Controllers;



[ApiController]
[Route("api/customers")]
public class Customers: ControllerBase
{
     //datafield
    public readonly AppDbContext _Customers;
    //constructor

    public Customers(AppDbContext context)
    {
        _Customers = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get_Customers()
    {
        var get_Customers = await _Customers.Customers.ToListAsync();
        {
            if (get_Customers == null)
            {
                return BadRequest("No Customers Found");
            }
            
            return Ok(get_Customers);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get_Customer(int id)
    {
        if (id < 0)
        {
            return BadRequest("Invalid Id");
        }
        var search=await _Customers.Customers.FirstOrDefaultAsync(items_id=>items_id.CustomerId==id);
        {
            if (search == null)
            {
                return BadRequest("No Customers Found");
            }
            return Ok(search);
        }
        
        
    }


}