using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Amigo;

namespace WebApp.ApiServices
{
    public class AmigoApi : IAmigoApi
    {
        private readonly HttpClient _httpClient;

        public AmigoApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("http://localhost:50382/");
        }
        public async Task<CriarAmigoViewModel> PostAsync(CriarAmigoViewModel criarAmigoViewModel)
        {
            var criarAmigoViewModelJson = JsonConvert.SerializeObject(criarAmigoViewModel);
                
            var conteudo = new StringContent(criarAmigoViewModelJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/amigos", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarAmigoViewModel;  
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                criarAmigoViewModel.Erros = erros;

                return criarAmigoViewModel;
            }

            return criarAmigoViewModel;

        }
        public async Task<List<ListarAmigoViewModel>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/amigos");

            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarAmigoViewModel>>(responseContent);

            return list;
        }

        public async Task<ListarAmigoViewModel> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync("api/amigos" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ListarAmigoViewModel>(responseContent);

        }



    }
}
    
