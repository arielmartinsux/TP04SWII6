using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP04SWII6.Models;

// Gabriel Martins Alves da Silva - CB3021521

namespace TP04SWII6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JogoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
        {
            var jogos = await _context.Jogos.ToListAsync();
            return Ok(jogos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            return jogo == null ? NotFound() : Ok(jogo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJogo(Jogo jogo)
        {
            // Se o modelo não for válido, retorna erro 400 com os detalhes
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // O Id será gerado automaticamente pelo banco de dados
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            // Retorna a resposta indicando que o jogo foi criado com sucesso
            return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJogo(int id, Jogo jogo)
        {
            if (id != jogo.Id) return BadRequest();
            _context.Entry(jogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return NotFound();
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
