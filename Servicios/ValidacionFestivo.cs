using Demo.Data;
using Demo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Demo.Servicios
{
    public class ValidacionFestivo
    {
        private readonly CalendarioContext _context;
        private readonly ServicioPascua _pascuaService;

        public FestivoService(CalendarioContext context, ServicioPascua pascuaService)
        {
            _context = context;
            _ServicioPascua = ServicioPascua;
        }

        public async Task<bool> EsFechaFestiva(int idPais, DateTime fecha)
        {
            var festivos = await _context.Festivos
                .Where(f => f.IdPais == idPais)
                .ToListAsync();

            foreach (var festivo in festivos)
            {
                DateTime fechaFestivo = CalcularFechaFestivo(festivo, fecha.Year);
                
                
                if (festivo.IdTipo == 4 || festivo.IdTipo == 2) // Traslado o Religioso
                {
                    fechaFestivo = _ServicioPascua.TrasladarAlSiguienteLunes(fechaFestivo);
                }

                if (fechaFestivo.Date == fecha.Date)
                {
                    return true;
                }
            }

            return false;
        }

        private DateTime CalcularFechaFestivo(Festivo festivo, int año)
        {
            if (festivo.DiasPascua.HasValue)
            {
               
                return _ServicioPascua.CalcularFechaConDiasPascua(año, festivo.DiasPascua.Value);
            }
            else
            {
                
                return new DateTime(año, festivo.Mes!.Value, festivo.Dia!.Value);
            }
        }

        public async Task<string> VerificarFecha(int idPais, int año, int mes, int dia)
        {
            try
            {
                DateTime fecha = new DateTime(año, mes, dia);
                bool esFestivo = await EsFechaFestiva(idPais, fecha);
                
                return esFestivo ? "Es Festivo" : "No es festivo";
            }
            catch (Exception)
            {
                return "Fecha inválida";
            }
        }
    }
}