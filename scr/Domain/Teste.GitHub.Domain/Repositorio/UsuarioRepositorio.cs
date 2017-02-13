using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.GitHub.Domain.Context;
using Teste.GitHub.Domain.Entidades;

namespace Teste.GitHub.Domain.Repositorio
{
    public class UsuarioRepositorio
    {
        public void CadastrarUsuario(Usuario usuario)
        {
            using (var _context = new DbContextGit())
            {
                _context.Usurios.Add(usuario);
                _context.SaveChanges();
            }
        }


        //Quando falamos de coleções temos 3 coleçoes principais
        //IEnumerable -> Lista somente leitus
        //IQueryable -> Lista leitura e pesquisa
        //IList -> Lista leitura, pesquisa, gravacao = DESDE O .NET 2.0
        //IColletion -> Alternativa mais RECENTE, MODERNA, LEVE AO ILIST = .NET 4.0

        /*public Usuario BuscarPorId(int id)
        {
            using (var _context = new DbContextGit())
            {
        
                return _context.Usurios.Single(p => p.UsuarioId == id);
            }
        }
        */

        public void CadastrarTipoUsuario(TipoUsuario tipoUser)
        {
            using (var _context = new DbContextGit())
            {
                _context.TipoUsuarios.Add(tipoUser);
                _context.SaveChanges();
            }
        }

        public IList<Usuario> ListarUsuarios()
        {
            using (var _context = new DbContextGit())
            {
                return _context.Usurios.Include("TipoUsuario").Where(t => t.Ativo == true).OrderBy(t => t.NomeUsuario).ToList();
                //return _context.Usurios.Where(t => t.Ativo == true).OrderBy(t => t.NomeUsuario).ToList();
            }

        }

        public List<TipoUsuario> ListaTiposUsuarios()
        {

            using (var _context = new DbContextGit())
            {
                return _context.TipoUsuarios.Where(t => t.Ativo == true).OrderBy(t => t.NomeTipoUsuario).ToList();
            }

        }

        public Usuario BuscarPorId(int id)
        {
            using (var _context = new DbContextGit())
            {
                return _context.Usurios.Find(id);

            }

        }


    }
}
