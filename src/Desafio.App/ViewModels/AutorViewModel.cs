using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.App.ViewModels
{
    public class AutorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo precisa ter no max {1} caracteres")]
        public string Email { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [DisplayName("País de Origem")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string PaisOrigem { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo precisa ter {1} caracteres")]
        public string CPF { get; set; }

        public IEnumerable<ObraViewModel> Obras { get; set; }
    }
}
