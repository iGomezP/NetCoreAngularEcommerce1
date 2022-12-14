using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    // Injecting
    private readonly StoreContext _context;
    public ProductsController(StoreContext context)
    {
      _context = context;
    }

    [HttpGet]
    // Make async method to liberate the process
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _context.Products.ToListAsync();
      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _context.Products.FindAsync(id);
    }
  }
}