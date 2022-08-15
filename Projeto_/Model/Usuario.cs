using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        public int Idade { get; set; }

        [MaxLength(20)]
        public string Sexo { get; set; }

        [MaxLength(20)]
        public string DocumentoTipo { get; set; }

        [MaxLength(20)]
        public string Documento { get; set; }

        [MaxLength(100)]
        public string Rua { get; set; }

        public int Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(100)]
        public string Bairro { get; set; }
        [MaxLength(100)]
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [MaxLength(100)]
        public string Pais { get; set; }

    }
}