namespace LavacarSystem.Entidades
{
    public class Cliente : Persona
    {
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}