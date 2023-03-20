public class Foto : ElementoBase
{
    public string Dimensiones { get; set; }

    public Foto(string nombre, string dimensiones) : base(nombre)
    {
        Dimensiones = dimensiones;
    }

    public override double ObtenerPeso()
    {
        return Nombre.Length;
    }
}