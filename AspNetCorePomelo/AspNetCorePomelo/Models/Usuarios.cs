using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePomelo.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }
        public string Nivel { get; set; }
    }
}
