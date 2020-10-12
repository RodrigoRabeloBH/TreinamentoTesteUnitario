using System;
using System.ComponentModel.DataAnnotations;

namespace Totvs.Locadora.Api.ViewModels
{
    public class FilmeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é um campo requerido!")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "{0} precisa conter pelo menos 3 caracteres e no máximo {1}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} é um campo requerido!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} precisa conter pelo menos 3 caracteres e no máximo {1}")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "{0} é um campo requerido!")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "{0} é um campo requerido!")]
        public string DataLancamento { get; set; }
    }
}
