using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtAPI_for_Angular_Application.Context;
using ArtAPI_for_Angular_Application.Models;

namespace ArtAPI_for_Angular_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductArtController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductArtController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductArt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getartwork()
        {
            var art = await _context.artwork.ToListAsync();

            return Ok(art);

        }


        // GET: api/ProductArt/5
        // GET: api/Products/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] Guid id)
        {

            var art = await _context.artwork.FirstOrDefaultAsync(x => x.Id == id);

            if (art == null)
            {
                return NotFound();
            }

            return Ok(art);

        }

        // POST: api/ProductArt
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();

            await _context.artwork.AddAsync(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT: api/ProductArt/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute]Guid id, Product product)
        {
            var art = await _context.artwork.FindAsync(id);

            if ( art == null)
            {
                return NotFound();
            }

            art.name = product.name;
            art.url = product.url;
            art.price = product.price;

            await _context.SaveChangesAsync();

            return Ok(art);


        }

        // DELETE: api/ProductArt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]Guid id)
        {
            var art = await _context.artwork.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            _context.artwork.Remove(art);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
