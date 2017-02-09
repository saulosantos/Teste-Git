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


        public Usuario BuscarPorId(int id)
        {
            using (var _context = new DbContextGit())
            {
        
                return _context.Usurios.Single(p => p.UsuarioId == id);
            }
        }
    }
}
