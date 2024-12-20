using Microsoft.AspNetCore.Mvc;
using SvitloServerApi.Interface;
using Telegram.Bot;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SvitloServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FromToTelegramController : ControllerBase
    {
        private readonly ITelegramBotService _telegramBotService;

        public FromToTelegramController(ITelegramBotService telegramBotService)
        {
            _telegramBotService = telegramBotService;
        }
        //POST: api/<FromToTelegramController>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromQuery] long chatId, [FromQuery] string message)
        {
            await _telegramBotService.SendMessage(chatId, message);
            return Ok("Ready");
        }
        // GET: api/<FromToTelegramController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //status bot
            return new string[] { "value1", "value2" };
        }
        // PUT api/<FromToTelegramController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FromToTelegramController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
