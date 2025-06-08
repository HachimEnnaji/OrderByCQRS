using Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(CreateOrderHandler handler) : ControllerBase
    {

        private readonly CreateOrderHandler _handler = handler;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand cmd)
        {
            if (cmd.Items is null || !cmd.Items.Any())
            {
                return BadRequest("Order must have at least one order");
            }

            var id = _handler.Handle(cmd);

            return CreatedAtAction(nameof(Create), new { id }, null);
        }
    }
}
