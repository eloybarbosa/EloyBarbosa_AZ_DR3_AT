using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAmigo.Resources.AmigoResource
{
    public class AmigoRequest
    {
        public string UrllFoto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public List<string> Erros()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                list.Add("Nome é Obrigatório");

            return list;
        }
    }

    
}

