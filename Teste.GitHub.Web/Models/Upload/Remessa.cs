using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste.GitHub.Web.Models.Upload
{
    public class Remessa
    {

        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }

        public int IdCadastrado { get; set; }


        public string ArquivoCaminho { get; set; }

        public string extencao { get; set; }


    }
}