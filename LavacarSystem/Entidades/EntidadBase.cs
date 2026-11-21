namespace LavacarSystem.Entidades
{
    public abstract class EntidadBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El identificador no puede ser negativo.");
                id = value;
            }
        }
    }
}