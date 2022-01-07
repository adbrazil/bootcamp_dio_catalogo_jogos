using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using catalogoJogos.Exceptions;
using catalogoJogos.InputModel;
using catalogoJogos.services;
using catalogoJogos.ViewModel;

namespace catalogoJogos.Controllers;

[ApiController]
[Route("/api/V1/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;


    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
    {
        var usuarios = await _usuarioService.Obter(pagina, quantidade);
        if (usuarios.Count() == 0)
            return NoContent();
        return Ok(usuarios);
    }

    [HttpGet("{idUsuario:guid}")]
    public async Task<ActionResult<List<UsuarioInputModel>>> Obter(Guid idUsuario)
    {
        var usuario = await _usuarioService.Obter(idUsuario);

        if (usuario == null)
            return NoContent();

        return Ok(usuario);
    }
    [HttpPost]
    public async Task<ActionResult<List<UsuarioInputModel>>> InserirUsuario([FromBody] UsuarioInputModel usuarioInputModel)
    {
        try
        {
            var usuario = await _usuarioService.Inserir(usuarioInputModel);
            return Ok(usuario);

        }
        catch (ItemJaCadastradoException ex)
        {
            return UnprocessableEntity("Já existe um Usuario com essas informações");
        }

    }

    [HttpPut("{idUsuario:guid}")]
    public async Task<ActionResult> AtualizarUsuario([FromRoute] Guid idUsuario, [FromBody] UsuarioInputModel usuarioInputModel)
    {
        try
        {
            await _usuarioService.Atualizar(idUsuario, usuarioInputModel);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este Usuário");
        }

    }

    [HttpPatch("{idUsuario:guid}/nome/{nome}")]
    public async Task<ActionResult> AtualizarUsuario([FromRoute] Guid idUsuario, [FromRoute] String nome)
    {
        try
        {
            await _usuarioService.Atualizar(idUsuario, nome);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este Usuário");
        }
    }

    [HttpDelete("{idUsuario:guid}")]
    public async Task<ActionResult> ApagaUsuario([FromRoute] Guid idUsuario)
    {
        try
        {
            await _usuarioService.Remover(idUsuario);
            return Ok();

        }
        catch (ItemNaoCadastradoException ex)
        {
            return NotFound("Não existe este Usuário");
        }
    }
}
