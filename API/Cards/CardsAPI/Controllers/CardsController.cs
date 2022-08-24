using CardsAPI.Data;
using CardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private CardsDbContext cardsDbContext;
        public CardsController(CardsDbContext cardsDbContext)
        {
            this.cardsDbContext = cardsDbContext;
        }
        //Get all cards
        [HttpGet]
        public async Task<IActionResult> GetAllCard()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(cards);
        }
        //Get single card
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card != null) { return Ok(card); }
            else { return NotFound("Card Not Found"); }
        }
        //Add card
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();
            await cardsDbContext.Cards.AddAsync(card);
            await cardsDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCard), new Card { Id = card.Id }, card);

        }
        //Updating a card
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Card card)
        {
            var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                existingCard.CardHolderName = card.CardHolderName;
                existingCard.CardNumber = card.CardNumber;
                existingCard.ExpireMonth = card.ExpireMonth;
                existingCard.ExpireYear = card.ExpireYear;
                existingCard.CVC = card.CVC;
                await cardsDbContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            else { return NotFound("Card not found for update"); }
        }
        //Deleting a card
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                cardsDbContext.Remove(existingCard);
                await cardsDbContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            else { return NotFound("Card not found for delete"); }

        }
    }
}
