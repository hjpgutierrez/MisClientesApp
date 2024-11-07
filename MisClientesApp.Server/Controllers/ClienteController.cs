using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisClientesApp.Server.Models;
using MisClientesApp.Server.Services;

namespace MisClientesApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;
        public ClienteController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Cliente>> Get() {
            return await _mongoDBService.GetAsync();
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente) {
            await _mongoDBService.CreateAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}
