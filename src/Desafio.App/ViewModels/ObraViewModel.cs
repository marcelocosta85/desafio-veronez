using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.App.ViewModels
{
    public class ObraViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Autor")]
        public Guid AutorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(240, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
        [DisplayName("Data da Publicação ")]
        public DateTime DataPublicacao { get; set; }
        [DisplayName("Data da Exposição ")]
        public DateTime DataExposicao { get; set; }
        public AutorViewModel Autor { get; set; }
        public IEnumerable<AutorViewModel> Autores { get; set; }
    }
}
