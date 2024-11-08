using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestión_de_Inventario_de_Productos
{
    public class Producto
    {
        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:C}:");
        }

    }
}
