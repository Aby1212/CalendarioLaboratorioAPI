namespace Demo.Entidades
{
    public class Festivo
    {
        public int Id { get; set; }
        public int IdPais { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public int? DiasPascua { get; set; }
        public int IdTipo { get; set; }
        
        // Navegación
        public Pais Pais { get; set; } = null!;
        public TipoFestivo TipoFestivo { get; set; } = null!;
    }
}