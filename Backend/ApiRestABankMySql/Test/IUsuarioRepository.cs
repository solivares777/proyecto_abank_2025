using ApiRestABankMySql.Model;

namespace ApiRestABankMySql.Test
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task<int> Create(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
