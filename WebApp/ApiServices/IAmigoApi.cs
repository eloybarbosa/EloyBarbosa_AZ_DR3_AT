﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Amigo;

namespace WebApp.ApiServices
{
    public interface IAmigoApi
    {
        Task<CriarAmigoViewModel> PostAsync(CriarAmigoViewModel criarAmigoViewModel);
        Task<List<ListarAmigoViewModel>> GetAsync();

    }
}