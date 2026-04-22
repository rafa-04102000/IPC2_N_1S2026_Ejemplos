using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ConfigService _configService;
        public ConfigController(ConfigService configService)
        {
            _configService = configService;
        }

        [HttpPost("cargar")]
        public async Task<IActionResult> Cargar(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("No se seleccionó ningún archivo.");

            try
            {
                // Leemos el contenido del archivo subido
                using var reader = new StreamReader(archivo.OpenReadStream());
                string xmlContent = await reader.ReadToEndAsync();

                var xmlRespuesta = _configService.CargarConfiguracion(xmlContent);

                // Esto asegura que la cabecera sea 'application/xml'
                return Content(xmlRespuesta, "application/xml");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar el archivo: {ex.Message}");
            }
        }
    }
}
