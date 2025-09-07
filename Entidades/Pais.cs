namespace Demo.Entidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        
        // Navegación
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
        public ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
    }
}