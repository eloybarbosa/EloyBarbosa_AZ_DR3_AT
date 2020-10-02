using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiAmigo.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApiAmigo.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAmigo.Resources.AmigoResource
{
    [Route("api/amigos")]
    [ApiController]
    public class AmigosController : ControllerBase
    {

        private readonly WebApiAmigoContext _context;
        private readonly IMapper _mapper;

        public AmigosController(WebApiAmigoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {


            var list = BuscarAmigos();

            return Ok(list);
        }

        

        // GET api/<AmigosController>/5
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute]Guid id)
        {
            var response = BuscarAmigoPor(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        

        // POST api/<AmigosController>
        [HttpPost]
        public ActionResult Post([FromBody] AmigoRequest amigoRequest)
        {
            var erros = amigoRequest.Erros();

            if (erros.Any())
                return UnprocessableEntity(erros);


            var response = CriarAmigo(amigoRequest);

            return CreatedAtAction(nameof(Get), new { response.Id }, response);
        }

       

        // PUT api/<AmigosController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] AmigoRequest request)
        {
            var response = BuscarAmigoPor(id);

            if (response == null)
                return NotFound();

            AlterarAmigo(id, request);

            return NoContent();
            
        }

       

        // DELETE api/<AmigosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var response = BuscarAmigoPor(id);

            if (response == null)
                return NotFound();

            ExcluirAmigo(id);

            return NoContent();
        }


        [HttpGet("{id}/paises")]
        public ActionResult GetPaisesDoAmigo([FromRoute] Guid id)
        {
            var amigo = _context.Amigos.Find(id);

            if (amigo == null)
                return NotFound();

            var paises = _context.Paises.Where(x => x.AmigoId == id).ToList();

            var response = _mapper.Map<List<PaisResponse>>(paises);

            return Ok(response);
        }

        [HttpPost("{id}/paises")]
        public ActionResult PostPaisesDoAmigo([FromRoute]Guid id, [FromBody]PaisRequest request)
        {
            var amigo = _context.Amigos.Find(id);

            if (amigo == null)
                return NotFound();

            var response = CriarPais(id, request);

            return CreatedAtAction(nameof(PostPaisesDoAmigo), new { response.Id }, response );




        }

        

        private IEnumerable<AmigoResponse> BuscarAmigos()
        {
            var amigos = _context.Amigos.ToList();

            return _mapper.Map<IEnumerable<AmigoResponse>>(amigos);
        }
        private AmigoResponse BuscarAmigoPor(Guid id)
        {
            var amigo = _context.Amigos.Find(id);
            if (amigo == null)
                return null;

            return _mapper.Map<AmigoResponse>(amigo);

        }

       
        private AmigoResponse CriarAmigo(AmigoRequest amigoRequest)
        {
            var amigo = _mapper.Map<Amigo>(amigoRequest);
            amigo.Id = Guid.NewGuid();

            _context.Amigos.Add(amigo);
            _context.SaveChanges();

            return _mapper.Map<AmigoResponse>(amigo);
        }
        private void AlterarAmigo(Guid id, AmigoRequest request)
        {

            var amigo = _context.Amigos.Find(id);
            amigo = _mapper.Map(request, amigo);

            _context.Amigos.Update(amigo);
            _context.SaveChanges();

        }
        private void ExcluirAmigo(Guid id)
        {
            var amigo = _context.Amigos.Find(id);
            if (amigo == null)
                return;

            _context.Amigos.Remove(amigo);
        }

        private PaisResponse CriarPais(Guid amigoId, PaisRequest request)
        {
            var pais = _mapper.Map<Pais>(request);
            pais.AmigoId = amigoId;


            _context.Paises.Add(pais);
            _context.SaveChanges();

            var response = _mapper.Map<PaisResponse>(pais);

            return response;

        }

    }

    
}
 
