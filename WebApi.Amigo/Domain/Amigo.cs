using System;
using System.Collections.Generic;

namespace WebApiAmigo.Domain
{
    public class Amigo
    {
        public Guid Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public List<Pais> Paises { get; set; }

    }
}
