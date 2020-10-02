using System;

namespace WebApiAmigo.Domain
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Guid AmigoId { get; set; }
    }
}
