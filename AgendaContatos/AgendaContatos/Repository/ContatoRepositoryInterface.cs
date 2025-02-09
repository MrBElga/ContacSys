using AgendaContatos.Models;

namespace AgendaContatos.Repository
{
    public interface ContatoRepositoryInterface
    {
        Contato ListarPorId(int id);
        List<Contato> BuscarTodos(); 
        Contato Adicionar(Contato contato);
        Contato Alterar(Contato contato);
        bool Apagar(int id);
    }
}