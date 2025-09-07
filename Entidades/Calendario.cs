namespace Demo.Entidades
{
    public class Calendario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTipo { get; set; }
        public string? Descripcion { get; set; }
        public int IdPais { get; set; }
        
        // Navegación
        public Tipo Tipo { get; set; } = null!;
        public Pais Pais { get; set; } = null!;
    }
}
