using CrudApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CargosController : ControllerBase
{

    private readonly CargoRepository _repo;

    public CargosController(CargoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IEnumerable<Cargo>> Get()
    {
        return await _repo.GetCargos();
    }
}