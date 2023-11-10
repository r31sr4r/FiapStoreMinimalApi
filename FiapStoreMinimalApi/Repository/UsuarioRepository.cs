using FiapStoreMinimalApi.Entidade;
using FiapStoreMinimalApi.Interface;

namespace FiapStoreMinimalApi.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private IList<Usuario> _usuarios = new List<Usuario>();

    public void AtualizarUsuario(Usuario usuario)
    {
        var usuarioParaAlterar = ObterUsuarioPorId(usuario.Id);
        if (usuarioParaAlterar != null)
            usuarioParaAlterar.Nome = usuario.Nome;
    }

    public void CadastrarUsuario(Usuario usuario)
    {
        _usuarios.Add(usuario);
    }

    public IList<Usuario> ObterTodosUsuarios()
    {
        return _usuarios;
    }

    public Usuario ObterUsuarioPorId(int id)
    {
        return _usuarios.FirstOrDefault(usuario => usuario.Id == id);
    }

    public void RemoverUsuario(int id)
    {
        _usuarios.Remove(ObterUsuarioPorId(id));
    }
}
