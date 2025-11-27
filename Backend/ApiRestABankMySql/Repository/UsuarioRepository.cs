using ApiRestABankMySql.data;
using ApiRestABankMySql.Model;
using Dapper;

namespace ApiRestABankMySql.Repository
{
    public class UsuarioRepository
    {
        private readonly MySqlContext _context;

        public UsuarioRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var sql = "SELECT * FROM Usuarios;";
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<Usuario>(sql);
        }

        public async Task<Usuario?> GetById(int id)
        {
            var sql = "SELECT * FROM Usuarios WHERE Id = @Id;";
            using var conn = _context.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<int> Create(Usuario user)
        {
            var sql = @"INSERT INTO Usuarios (Nombres, Apellidos, FechaNacimiento, Direccion)
                        VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Direccion);
                        SELECT LAST_INSERT_ID();";

            using var conn = _context.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(sql, user);
        }

        public async Task<int> Update(Usuario user, int id)
        {
            var sql = @"UPDATE Usuarios SET 
                        Nombres=@Nombres,
                        Apellidos=@Apellidos,
                        FechaNacimiento=@FechaNacimiento,
                        Direccion=@Direccion
                        WHERE Id=@Id";

            using var conn = _context.CreateConnection();
            return await conn.ExecuteAsync(sql, new { user.Nombres, user.Apellidos, user.FechaNacimiento, user.Direccion, Id = id });
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Usuarios WHERE Id = @Id;";
            using var conn = _context.CreateConnection();
            return await conn.ExecuteAsync(sql, new { Id = id });
        }
    }
}
