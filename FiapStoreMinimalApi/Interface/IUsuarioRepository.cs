using FiapStoreMinimalApi.Entidade;

namespace FiapStoreMinimalApi.Interface;

public interface IUsuarioRepository
{
    IList<Usuario> ObterTodosUsuarios();
    Usuario ObterUsuarioPorId(int id);
    void CadastrarUsuario(Usuario usuario);
    void AtualizarUsuario(Usuario usuario);
    void RemoverUsuario(int id);
}
