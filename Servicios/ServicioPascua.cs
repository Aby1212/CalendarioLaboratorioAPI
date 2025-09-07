namespace Demo.Servicios
{
    public class ServicioPascua
    {
        public DateTime CalcularDomingoPascua(int año)
        {
            // Algoritmo de cálculo de Pascua
            int a = año % 19;
            int b = año % 4;
            int c = año % 7;
            int d = (19 * a + 24) % 30;
            int dias = d + (2 * b + 4 * c + 6 * d + 5) % 7;
            
            
            DateTime domingoRamos = new DateTime(año, 3, 15).AddDays(dias);
            DateTime domingoPascua = domingoRamos.AddDays(7);
            
            
            if (domingoPascua.Month == 4)
            {
                return domingoPascua;
            }
            
            
            return domingoPascua;
        }

        public DateTime CalcularFechaConDiasPascua(int año, int diasPascua)
        {
            DateTime domingoPascua = CalcularDomingoPascua(año);
            return domingoPascua.AddDays(diasPascua);
        }

        public DateTime TrasladarAlSiguienteLunes(DateTime fecha)
        {
            // Si no es lunes, trasladar al siguiente lunes
            if (fecha.DayOfWeek != DayOfWeek.Monday)
            {
                int diasHastaLunes = ((int)DayOfWeek.Monday - (int)fecha.DayOfWeek + 7) % 7;
                if (diasHastaLunes == 0) diasHastaLunes = 7; // Si es domingo
                return fecha.AddDays(diasHastaLunes);
            }
            return fecha;
        }
    }
}