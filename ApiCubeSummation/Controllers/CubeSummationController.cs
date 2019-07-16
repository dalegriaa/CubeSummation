using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCubeSummation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubeSummationController : ControllerBase
    {
        private readonly ICubeSummationService cubeSummationService;
        
        public CubeSummationController(ICubeSummationService cubeSummationService)
        {
            this.cubeSummationService = cubeSummationService;
        }

        public IActionResult GetSum(string routeArchive)
        {
            try
            {
                if (String.IsNullOrEmpty(routeArchive) || String.IsNullOrEmpty(routeArchive))
                {
                    return BadRequest("Por favor cargue los archivos");
                }
                var resultSum = cubeSummationService.GetOutput(routeArchive);
                return new ObjectResult(resultSum);
            }
            catch (Exception ex)
            {

                return new ObjectResult(ex.Message);
            }
        }
    }
}