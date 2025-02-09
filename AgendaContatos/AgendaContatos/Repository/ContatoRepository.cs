using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos.Repository
{
    public class ContatoRepository : ContatoRepositoryInterface
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // Buscar contato por id no banco
        public Contato ListarPorId(int id)
        {
            var contato = _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato != null)
                return contato;
            throw new Exception("Contato não encontrado!");



        }

        // Buscar todos os contatos no banco
        public List<Contato> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        // Adicionar contato no banco
        public Contato Adicionar(Contato contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public Contato Alterar(Contato contato)
        {
            _bancoContext.Contatos.Update(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            Contato contato = ListarPorId(id);

            if (contato != null)
            {
                _bancoContext.Contatos.Remove(contato);
                _bancoContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
