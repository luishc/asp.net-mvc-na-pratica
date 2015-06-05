using System;
using System.ComponentModel;

namespace TISelvagem.Dominio
{
    public class Aluno
    {
        public int id { get; set; }
        public string Nome { get; set; }

        [DisplayName("Mãe")]
        public string Mae { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

    }
}
