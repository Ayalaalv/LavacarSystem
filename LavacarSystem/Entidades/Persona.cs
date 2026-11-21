namespace LavacarSystem.Entidades
{
    public class Persona : EntidadBase
    {
        private string nombre = string.Empty;
        private string telefono = string.Empty;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre es obligatorio.");
                if (value.Trim().Length > 100)
                    throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");
                nombre = value.Trim();
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono es obligatorio.");
                if (value.Trim().Length > 15)
                    throw new ArgumentException("El teléfono no puede tener más de 15 caracteres.");
                telefono = value.Trim();
            }
        }
    }
}