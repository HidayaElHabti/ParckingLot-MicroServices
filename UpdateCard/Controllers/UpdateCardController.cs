using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpdateCard.Data;

namespace UpdateCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCardController : ControllerBase
    {
        public CardDbContext _cardDbContext { get; }
        public UpdateCardController(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }
        [HttpPut("{id},{ammount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddMoney(int id, int ammount)
        {
            var card = await _cardDbContext.Cards.FindAsync(id);
            if (card == null)
                return NotFound();
            card.Balance += ammount;
            await _cardDbContext.SaveChangesAsync();

            return Ok(card);
        }
    }
}
