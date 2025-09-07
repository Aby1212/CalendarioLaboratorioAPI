namespace Demo.Entidades
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Tipo1 { get; set; } = string.Empty;
        
        // Navegación
        public ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
    }
}