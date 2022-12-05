using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParckingLot.Data;

namespace ParckingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParckingLotController : ControllerBase
    {
        
        public CardDbContext _cardDbContext { get; }
        public ParckingLotController(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }

        [HttpGet("Enter{id}")]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InsertCard(int id)
        {
            var card = await _cardDbContext.Cards.FindAsync(id);
            if(card == null)
                return NotFound();

            if (card.LastEntered == null ||
                DateTime.UtcNow.Subtract(card.LastEntered.Value) > TimeSpan.FromMinutes(1))
                if ((card.Balance - 4) < 0)
                    return BadRequest("Not enough money!");
                else
                    card.Balance -= 4;

            card.LastEntered = DateTime.UtcNow;
            await _cardDbContext.SaveChangesAsync();

            return Ok(card);
        }

        [HttpGet("Exit{id}")]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PopCard(int id)
        {
            var card = await _cardDbContext.Cards.FindAsync(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }
    }
}
