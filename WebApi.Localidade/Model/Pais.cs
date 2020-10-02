using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Localidade.Model
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public String Foto { get; set; }
        public List<Localidade> Localidaes{ get; set;}

    }
}
