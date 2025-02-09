using AgendaContatos.Models;
using AgendaContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace AgendaContatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly ContatoRepositoryInterface _contatoRepository;
        public ContatosController(ContatoRepositoryInterface contatoRepository) {
            _contatoRepository = contatoRepository;
        }

        // GET: ContatosController
        public IActionResult Index()
        {
           List<Contato> contatos = _contatoRepository.BuscarTodos();
            return View(contatos);
        }

        //metodos get
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Contato contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            Contato contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepository.Apagar(id);
                if (apagado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Logar a exceção (ex) se necessário
                return NotFound();
            }
        }

        //metodos post
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            if (contato == null)
                return NotFound();
            _contatoRepository.Alterar(contato);
            return RedirectToAction("Index");
        }
    }
}
