using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Amigo
{
    public class CriarAmigoViewModel
    {
        public IFormFile Foto { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public List<string> Erros { get; set; } = new List<string>();
    }
}