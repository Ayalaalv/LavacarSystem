namespace LavacarSystem.Entidades
{
    public class Vehiculo : EntidadBase
    {
        private string placa = string.Empty;
        private string marca = string.Empty;
        private int idCliente;

        public string Placa
        {
            get { return placa; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La placa es obligatoria.");

                string placaLimpia = value.Trim().ToUpper();

                if (placaLimpia.Length > 10)
                    throw new ArgumentException("La placa no puede tener más de 10 caracteres.");

                foreach (char caracter in placaLimpia)
                {
                    if (!char.IsLetterOrDigit(caracter))
                        throw new ArgumentException("La placa solo puede contener letras y números.");
                }

                placa = placaLimpia;
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca es obligatoria.");
                if (value.Trim().Length > 50)
                    throw new ArgumentException("La marca no puede tener más de 50 caracteres.");
                marca = value.Trim();
            }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Debe seleccionar el dueño del vehículo.");
                idCliente = value;
            }
        }

        public string NombreCliente { get; set; } = string.Empty;
    }
}