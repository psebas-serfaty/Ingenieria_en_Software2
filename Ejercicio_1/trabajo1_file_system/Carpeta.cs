    public class Carpeta : ElementoBase
    {
        public List<ElementoBase> Elementos { get; set; }

        public Carpeta(string nombre) : base(nombre)
        {
            Elementos = new List<ElementoBase>();
        }

        public override double ObtenerPeso()
        {
            double pesoTotal = 0;
            foreach (var elemento in Elementos)
            {
                pesoTotal += elemento.ObtenerPeso();
            }
            Peso = pesoTotal;
            return Peso;
        }

        public void AgregarElemento(ElementoBase elemento)
        {
            Elementos.Add(elemento);
            ObtenerPeso();
        }

        public double CalcularPesoTotal()
        {
            double pesoTotal = ObtenerPeso();
            foreach (var elemento in Elementos)
            {
                var carpeta = elemento as Carpeta;
                if (carpeta != null)
                {
                    pesoTotal += carpeta.CalcularPesoTotal();
                }
                else
                {
                    pesoTotal += elemento.Nombre.Length;
                }
            }
            return pesoTotal;
        }
    }
