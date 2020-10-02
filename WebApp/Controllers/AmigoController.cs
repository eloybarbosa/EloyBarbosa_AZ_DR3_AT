using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using WebApp.ApiServices;
using WebApp.Models.Amigo;

namespace WebApp.Controllers
{
    public class AmigoController : Controller
    {
        private readonly AmigoApi _amigoApi;

        public AmigoController(AmigoApi amigoApi)
        {
            _amigoApi = amigoApi;
        }

        // GET: AmigoController
        public async Task <ActionResult> Index()
        {
            var amigos = await  _amigoApi.GetAsync();

            return View(amigos);
        }

        // GET: AmigoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AmigoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AmigoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarAmigoViewModel criarAmigoViewModel)
        {

            var urlFoto = UploadFotoAmigo(criarAmigoViewModel.Foto);
            criarAmigoViewModel.UrlFoto = urlFoto;

            await _amigoApi.PostAsync(criarAmigoViewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // GET: AmigoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AmigoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AmigoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AmigoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private string UploadFotoAmigo(IFormFile foto)
        {
            var reader = foto.OpenReadStream();
            var cloudStorageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=eloybarbosa;AccountKey=ldZw0vVBXy6z6bnDwdFj5c/8QeHVsiPU/y5AzdrfeAkOkGs90VBQoJray2y7H4LVGikxR5FmkjdvOTIltPi2YQ==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("fotos-amigos");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();

            return destinoDaImagemNaNuvem;

        }
    }
}
