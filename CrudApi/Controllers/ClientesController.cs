using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{

    private readonly ClienteRepository _repo;

    public ClientesController(ClienteRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        try
        {
            var clientes = await _repo.GetId(id);

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        try
        {
            var clientes = await _repo.GetAll();

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Insert(Cliente c)
    {
        try
        {
            var id = await _repo.Insert(c);

            return Created("", new { id });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Cliente c)
    {
        try
        {
            await _repo.Update(id, c);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _repo.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}