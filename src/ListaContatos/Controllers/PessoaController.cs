using ListaContatos.Dtos.Pessoa;
using ListaContatos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ListaContatos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "BuscarPorId")]
        public async Task<ActionResult> Get(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //codigo 400 - solicitação invalida

            try
            {
                var user = await _service.Get(id);

                if (user != null)
                    return Ok(user);
                else
                    return StatusCode((int)HttpStatusCode.NotFound, "Pessoa não encontrada");

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDtoCreate pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //codigo 400 - solicitação invalida

            try
            {
                var result = await _service.Post(pessoa);
                if (result != null)
                {
                    //Uri redirectLink = new Uri(Url.Link("BuscarPorId", new { id = result.Id }));
                    //return Created(redirectLink, result);
                    return Ok(result);
                }
                else
                    return BadRequest();

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PessoaDtoUpdate pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //codigo 400 - solicitação invalida

            try
            {
                var result = await _service.Put(pessoa);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //codigo 400 - solicitação invalida

            try
            {
                bool result = await _service.Delete(id);
                if (result != false)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
