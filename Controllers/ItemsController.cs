using Microsoft.AspNetCore.Mvc;
using dotNetAPI.Models;

namespace dotNetAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/v1/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        // GET: api/v1/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(Guid id)
        {
            var item = await _itemService.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/v1/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(Guid id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                await _itemService.UpdateItem(item);
            }
            catch 
            {
                if (!await _itemService.ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _itemService.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // DELETE: api/v1/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(Guid id)
        {
            var item = await _itemService.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _itemService.DeleteItem(id);
            return NoContent();
        }
    }
}
