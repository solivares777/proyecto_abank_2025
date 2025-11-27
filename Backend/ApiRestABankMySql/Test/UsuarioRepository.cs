using ApiRestABankMySql.Model;
using ApiRestABankMySql.Repository;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiRestABankMySql.Test
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MySqlConnection");
        }

        private MySqlConnection GetConnection() => new MySqlConnection(_connectionString);

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            using var con = GetConnection();
            return await con.QueryAsync<Usuario>("SELECT * FROM usuarios");
        }

        public async Task<Usuario?> GetById(int id)
        {
            using var con = GetConnection();
            return await con.QueryFirstOrDefaultAsync<Usuario>(
                "SELECT * FROM usuarios WHERE Id = @Id",
                new { Id = id });
        }

        public async Task<int> Create(Usuario usuario)
        {
            using var con = GetConnection();
            var sql = @"INSERT INTO usuarios (Nombres, Apellidos, FechaNacimiento, Direccion) 
                    VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Direccion);
                    SELECT LAST_INSERT_ID();";

            return await con.ExecuteScalarAsync<int>(sql, usuario);
        }

        public async Task<bool> Delete(int id)
        {
            using var con = GetConnection();
            var result = await con.ExecuteAsync(
                "DELETE FROM usuarios WHERE Id = @Id", new { Id = id });
            return result > 0;
        }
    }
}
