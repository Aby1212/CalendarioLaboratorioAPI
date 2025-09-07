using Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controladores
{
    [ApiController]
    [Route("api/calendario")]
    public class CalendarioControladores : ControllerBase
    {
        private readonly ValidacionFestivo _validacionFestivo;

        public CalendarioController(ValidacionFestivo ValidacionFestivo)
        {
            _validacionFestivo = ValidacionFestivo;
        }

        [HttpGet("verificar/{idPais}/{año}/{mes}/{dia}")]
        public async Task<ActionResult<string>> VerificarFecha(
            int idPais, 
            int año, 
            int mes, 
            int dia)
        {
            var resultado = await _validacionFestivo.VerificarFecha(idPais, año, mes, dia);
            return Ok(resultado);
        }
    }
}