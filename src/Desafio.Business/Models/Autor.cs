using System;
using System.Collections.Generic;

namespace Desafio.Business.Models
{
    public class Autor : Entity
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PaisOrigem { get; set; }
        public string CPF { get; set; }

        public IEnumerable<Obra> Obras { get; set; }
    }
}
