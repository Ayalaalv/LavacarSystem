namespace LavacarSystem.Entidades
{
    public class Servicio : EntidadBase
    {
        private string nombre = string.Empty;
        private decimal precio;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del servicio es obligatorio.");
                if (value.Trim().Length > 100)
                    throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");
                nombre = value.Trim();
            }
        }

        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor que cero.");
                precio = value;
            }
        }
    }
}