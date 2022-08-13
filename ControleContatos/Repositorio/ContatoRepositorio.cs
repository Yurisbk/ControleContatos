using ControleContatos.Data;
using ControleContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        { 
            _bancoContext = bancoContext;
            
        
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Insere no Banco de Dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            var contatoDB = ListarId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

             _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;

        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel ListarId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
