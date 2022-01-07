using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using catalogoJogos.Exceptions;
using catalogoJogos.InputModel;
using catalogoJogos.services;
using catalogoJogos.ViewModel;

namespace catalogoJogos.Controllers;

[ApiController]
[Route("/api/V1/[controller]")]
public class JogosController : ControllerBase
{
    private readonly IJogoService _jogoService;


    public JogosController(IJogoService jogoService)
    {
        _jogoService = jogoService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
    {
        var jogos = await _jogoService.Obter(pagina, quantidade);
        if (jogos.Count() == 0)
            return NoContent();
        return Ok(jogos);
    }

    [HttpGet("{idJogo:guid}")]
    public async Task<ActionResult<List<JogoInputModel>>> Obter(Guid idJogo)
    {
        var jogo = await _jogoService.Obter(idJogo);

        if (jogo == null)
            return NoContent();

        return Ok(jogo);
    }
    [HttpPost]
    public async Task<ActionResult<List<JogoInputModel>>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
    {
        try
        {
            var jogo = await _jogoService.Inserir(jogoInputModel);
            return Ok(jogo);

        }
        catch (ItemJaCadastradoException ex)
        {
            return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
        }

    }

    [HttpPut("{idJogo:guid}")]
    public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
    {
        try
        {
            await _jogoService.Atualizar(idJogo, jogoInputModel);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este jogo");
        }

    }

    [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
    public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
    {
        try
        {
            await _jogoService.Atualizar(idJogo, preco);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este jogo");
        }
    }

    [HttpDelete("{idJogo:guid}")]
    public async Task<ActionResult> ApagaJogo([FromRoute] Guid idJogo)
    {
        try
        {
            await _jogoService.Remover(idJogo);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este jogo");
        }
    }
}
