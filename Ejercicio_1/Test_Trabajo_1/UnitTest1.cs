namespace Test_Trabajo_1
{
    public class UnitTest1
    {
        [Fact]
        public void Archivo_debeGenerarse()
        {
            // Arrange
            string nombre = "TestFile";
            string extension = ".txt";

            // Act
            var archivo = new Archivo(nombre, extension);

            // Assert
            Assert.Equal(nombre, archivo.Nombre);
            Assert.Equal(extension, archivo.Extension);
        }

        [Fact]
        public void ObtenerPeso_DebefuncionarEnArchivo()
        {
            // Arrange
            string nombre = "TestFile";
            string extension = ".txt";
            var archivo = new Archivo(nombre, extension);
            int expectedPeso = nombre.Length + extension.Length;

            // Act
            double peso = archivo.ObtenerPeso();

            // Assert
            Assert.Equal(expectedPeso, peso);
        }

        [Fact]
        public void FotoConPropiedadesValidasSeDebeGuardarse()
        { 
            // Arrange
            string nombre = "TestPhoto";
            string dimensiones = "100x100";

            // Act
            var foto = new Foto(nombre, dimensiones);

            // Assert
            Assert.Equal(nombre, foto.Nombre);
            Assert.Equal(dimensiones, foto.Dimensiones);
        }

        [Fact]
        public void ObtenerPesoDebeFuncionarConFotos()
        {
            // Arrange
            string nombre = "TestPhoto";
            string dimensiones = "100x100";
            var foto = new Foto(nombre, dimensiones);

            // Act
            double peso = foto.ObtenerPeso();

            // Assert
            Assert.Equal(nombre.Length, peso);
        }

        [Fact]
        public void CrearCarpeta_DebeCrearCarpetaVaciaConNombre()
        {
            // Arrange
            string nombreCarpeta = "Mi Carpeta";

            // Act
            Carpeta carpeta = new Carpeta(nombreCarpeta);

            // Assert
            Assert.NotNull(carpeta);
            Assert.Equal(nombreCarpeta, carpeta.Nombre);
            Assert.Empty(carpeta.Elementos);
            Assert.Equal(0, carpeta.ObtenerPeso());
        }

        [Fact]
        public void AgregarElemento_DebeAgregarElementoALaCarpetaYActualizarPeso()
        {
            // Arrange
            Carpeta carpeta = new Carpeta("Mi Carpeta");
            ElementoBase elemento = new Archivo("Mi Archivo", "txt");

            // Act
            carpeta.AgregarElemento(elemento);

            // Assert
            Assert.Single(carpeta.Elementos);
            Assert.Equal(elemento, carpeta.Elementos[0]);
            Assert.Equal(elemento.ObtenerPeso(), carpeta.ObtenerPeso());
            Assert.Equal(carpeta.ObtenerPeso(), carpeta.CalcularPesoTotal());
        }

        [Fact]
        public void CalcularPesoTotal_DebeCalcularPesoTotalDeLaCarpetaIncluyendoSusElementos()
        {
            // Arrange
            Carpeta carpeta = new Carpeta("Mi Carpeta");
            Archivo archivo1 = new Archivo("Archivo1", "txt");
            Archivo archivo2 = new Archivo("Archivo2", "txt");
            Carpeta subcarpeta = new Carpeta("Subcarpeta");
            Archivo archivo3 = new Archivo("Archivo3", "txt");

            subcarpeta.AgregarElemento(archivo3);
            carpeta.AgregarElemento(archivo1);
            carpeta.AgregarElemento(archivo2);
            carpeta.AgregarElemento(subcarpeta);

            // Act
            double pesoTotal = carpeta.CalcularPesoTotal();

            // Assert
            Assert.Equal(archivo1.Nombre.Length + archivo2.Nombre.Length + archivo3.Nombre.Length + subcarpeta.ObtenerPeso() + carpeta.Nombre.Length, pesoTotal);
        }

    }
}