using CrudApi.Models;
using Dapper;

public class ClienteRepository
{
    private readonly DbConnectionFactory _factory;

    public ClienteRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<Cliente?> GetId(int id)
    {
        using var db = _factory.Create();

        string sql = @"SELECT * 
                   FROM Cliente
                   WHERE Id = @id";

        return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { id });
    }


    public async Task<IEnumerable<Cliente>> GetAll()
    {
        using var db = _factory.Create();

        string sql = "SELECT * FROM Cliente";

        return await db.QueryAsync<Cliente>(sql);
    }

    public async Task<int> Insert(Cliente c)
    {
        using var db = _factory.Create();

        string sql = @"
        INSERT INTO Cliente
        (Nome,DataNascimento,Endereco,UF,CargoId)
        OUTPUT INSERTED.Id
        VALUES
        (@Nome,@DataNascimento,@Endereco,@UF,@CargoId)";

        return await db.ExecuteScalarAsync<int>(sql, c);
    }

    public async Task Update(int id, Cliente c)
    {
        using var db = _factory.Create();

        string sql = @"
        UPDATE Cliente SET
        Nome=@Nome,
        DataNascimento=@DataNascimento,
        Endereco=@Endereco,
        UF=@UF,
        CargoId=@CargoId
        WHERE Id=@Id";

        c.Id = id;

        await db.ExecuteAsync(sql, c);
    }

    public async Task Delete(int id)
    {
        using var db = _factory.Create();

        string sql = "DELETE FROM Cliente WHERE Id=@id";

        await db.ExecuteAsync(sql, new { id });
    }
}