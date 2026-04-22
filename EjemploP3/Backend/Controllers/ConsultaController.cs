using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet("clientes")]
        public IActionResult GetClientes()
        {
            return Ok(_consultaService.ObtenerTodosLosClientes());
        }

        [HttpGet("cliente/{nit}")]
        public IActionResult GetEstadoCuenta(string nit)
        {
            var resultado = _consultaService.ObtenerEstadoCuenta(nit);
            if (resultado == null) return NotFound(new { mensaje = "Cliente no encontrado" });

            return Ok(resultado);
        }

        [HttpGet("ingresos-bancos")]
        public IActionResult GetIngresosBancos([FromQuery] int mes, [FromQuery] int anio)
        {
            // Validación básica
            if (mes < 1 || mes > 12 || anio < 2000)
                return BadRequest(new { mensaje = "Fecha inválida" });

            var resultado = _consultaService.ObtenerIngresosPorBanco(mes, anio);
            return Ok(resultado);
        }

    }
}
