using ApiRestABankMySql.Model;

namespace ApiRestABankMySql.Test
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Usuario>> GetUsuarios() => _repo.GetAll();
    }
}
