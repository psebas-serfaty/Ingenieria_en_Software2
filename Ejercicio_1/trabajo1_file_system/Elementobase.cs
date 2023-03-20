public abstract class ElementoBase
{
    public string Nombre { get; set; }
    public double Peso { get; set; }

    public ElementoBase(string nombre)
    {
        Nombre = nombre;
        Peso = Nombre.Length;
    }

    public virtual double ObtenerPeso()
    {
        return Peso;
    }
}