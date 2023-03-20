    public class Archivo : ElementoBase
    {
        public string Extension { get; set; }

        public Archivo(string nombre, string extension) : base(nombre)
        {
            Extension = extension;
        }

        public override double ObtenerPeso()
        {
            Peso = Nombre.Length + Extension.Length;
            return Peso;
        }
    }
