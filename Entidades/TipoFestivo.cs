namespace Demo.Entidades
{
    public class TipoFestivo
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        
        // Navegación
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
    }
}