using System;

namespace Desafio.Business.Models
{
    public class Obra : Entity
    {
        public Guid AutorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataExposicao { get; set; }
        public Autor Autor { get; set; }
    }
}
