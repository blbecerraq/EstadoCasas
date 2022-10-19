using CeldasCore.Models;
using CeldasInfraestructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstadoCeldas.Controllers
{
    public class CeldaController : Controller
    {
        private readonly IStatus _iStatus;
        public CeldaController(IStatus iStatus)
        {
            _iStatus = iStatus;
        }
        [HttpPost("EstadoCeldas")]
        public IActionResult OnPostEstadoCeldas([FromBody] Request request)
        {
            Response response = new Response();
            try
            {
                var message = _iStatus.ValidationRequest(request);
                if (string.IsNullOrEmpty(message))
                {
                    response = _iStatus.CalculateValueCells(request);
                    return new JsonResult(response);
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
