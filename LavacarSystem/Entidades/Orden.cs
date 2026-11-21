namespace LavacarSystem.Entidades
{
    public class Orden : EntidadBase
    {
        public static readonly string[] EstadosValidos = { "Pendiente", "En proceso", "Terminado" };

        private string estado = "Pendiente";

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Estado
        {
            get { return estado; }
            set
            {
                if (!EstadosValidos.Contains(value))
                    throw new ArgumentException("El estado debe ser Pendiente, En proceso o Terminado.");
                estado = value;
            }
        }

        public Vehiculo Vehiculo { get; set; } = new Vehiculo();
        public Servicio Servicio { get; set; } = new Servicio();

        public decimal CalcularTotal()
        {
            return Servicio.Precio;
        }

        public int CalcularDiasTranscurridos()
        {
            return (DateTime.Now - Fecha).Days;
        }
    }
}