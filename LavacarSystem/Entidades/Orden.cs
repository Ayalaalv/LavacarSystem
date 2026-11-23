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

        public string NombreCliente
        {
            get { return Vehiculo.NombreCliente; }
        }

        public string Placa
        {
            get { return Vehiculo.Placa; }
        }

        public string NombreServicio
        {
            get { return Servicio.Nombre; }
        }

        public decimal Total
        {
            get { return CalcularTotal(); }
        }

        public int DiasTranscurridos
        {
            get { return CalcularDiasTranscurridos(); }
        }
    }
}