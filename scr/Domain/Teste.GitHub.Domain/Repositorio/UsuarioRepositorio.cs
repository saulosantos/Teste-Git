using System;
using System.Collections.Generic;
using System.Data.Entity;
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

                return _context.Usurios.Include("TipoUsuario").SingleOrDefault(t => t.UsuarioId == id);

            }

        }

        public void AtualizaUsuario(Usuario usuario)
        {
 
           
            using (var _context = new DbContextGit())
            {

                var usuarioBd = _context.Usurios.Find(usuario.UsuarioId);

                if (usuarioBd != null)
                {
                    usuarioBd.DataCadastro = DateTime.Now;
                    usuarioBd.NomeUsuario = usuario.NomeUsuario;
                    usuarioBd.LoginUser = usuario.LoginUser;
                    usuarioBd.Ativo = usuario.Ativo;
                    usuarioBd.TipoUsuarioId = usuario.TipoUsuarioId;
                    _context.Entry<Usuario>(usuarioBd).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                }


            }

        }

        public IList<TipoUsuario> ListaTipoUser()
        {
            using (var _context = new DbContextGit())
            {
                //var res = _context.ArquivosPessoas.Where(p => p.ArquivoPessoaId == id);

                return _context.TipoUsuarios.ToList();
            }

        }


        public Usuario verificaUsuario(Usuario usuario)
        {
            using (var _context = new DbContextGit())
            {
                usuario = _context.Usurios.FirstOrDefault(u => u.LoginUser == usuario.LoginUser && u.SenhaUsuario == usuario.SenhaUsuario);
                return (usuario);
            }
        }



    }
}
