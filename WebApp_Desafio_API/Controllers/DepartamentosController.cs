﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Desafio_API.ViewModels;
using WebApp_Desafio_BackEnd.Business;

namespace WebApp_Desafio_API.Controllers
{
    /// <summary>
    /// DepartamentosController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : Controller
    {
        private DepartamentosBLL bll = new DepartamentosBLL();

        /// <summary>
        /// Lista todos os departamento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartamentoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var _lst = this.bll.ListarDepartamentos();

                var lst = from departamento in _lst
                          select new DepartamentoResponse()
                          {
                              id = departamento.ID,
                              descricao = departamento.Descricao,
                          };

                return Ok(lst);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartamentoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("Obter")]
        public IActionResult Obter([FromQuery]int idDepartamento)
        {
            try
            {
                var departamento = this.bll.ObterDepartamento(idDepartamento);

                return Ok(departamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("Gravar")]
        public IActionResult Gravar([FromBody] DepartamentoRequest request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException("Request não informado.");

                var resultado = this.bll.GravarChamado(request.id,
                                                       request.descricao  );

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Exclui um chamado específico
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("Excluir")]
        public IActionResult Excluir([FromQuery] int idDepartamento)
        {
            try
            {
                var resultado = this.bll.ExcluirChamado(idDepartamento);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
