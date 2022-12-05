using CreateCard.Data;
using CreateCard.Models;
using CreateCard.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreateCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateCardController : ControllerBase
    {
        public CardDbContext _cardDbContext { get; }
        public CreateCardController(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Card>> GetCards()
        {
            var cards = await _cardDbContext.Cards.ToListAsync();
            return cards;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCard(int id)
        {
            var card = await _cardDbContext.Cards.FindAsync(id);
            return card == null ? NotFound() : Ok(card);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCard(CreateCardDto cardDto)
        {
            Card newCard = new Card(cardDto);
            await _cardDbContext.Cards.AddAsync(newCard);
            await _cardDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCard), new { id = newCard.Id }, newCard);
        }
    }
}
