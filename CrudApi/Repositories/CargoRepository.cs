using CrudApi.Controllers;
using CrudApi.Models;
using Dapper;

public class CargoRepository
{
    private readonly DbConnectionFactory _factory;

    public CargoRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Cargo>> GetCargos()
    {
        using var db = _factory.Create();
        return await db.QueryAsync<Cargo>("SELECT Id, Nome FROM Cargo");
    }

}