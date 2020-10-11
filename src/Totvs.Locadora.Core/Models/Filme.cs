using System;

namespace Totvs.Locadora.Core.Models
{
    public class Filme : Entity
    {
        public string Titulo { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; }
        public double Preco { get; set; }
    }
}
