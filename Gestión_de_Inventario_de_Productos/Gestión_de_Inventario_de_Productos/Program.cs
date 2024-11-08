using Gestión_de_Inventario_de_Productos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Gestion_de_Inventario_de_Productos
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.WriteLine("BIENVENIDOS AL SISTEMA DE GESTIÓN DE INVENTARIO");
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_\n");

            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.WriteLine("Cuantos productos desea agregar: ");
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_\n");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");

                string nombre;
                do
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("*********************************************************");
                        Console.WriteLine("El nombre no debe quedar vacío. FAVOR INTENTE NUEVAMENTE");
                        Console.WriteLine("*********************************************************\n");
                    }
                } while (string.IsNullOrWhiteSpace(nombre));

                decimal precio;
                do
                {
                    Console.Write("Precio: ");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Por favor, ingrese un número válido y positivo.");
                        Console.WriteLine("**********************************************\n");
                    }
                } while (precio <= 0);

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.WriteLine("Ingrese el precio mínimo para filtrar los productos: ");
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_\n");
            decimal precioMinimo = decimal.Parse(Console.ReadLine());

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
            Console.WriteLine("\nProductos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }
            Console.WriteLine("_--__--__--__--__--__--__--__--__--__--__--__--__--__--__--_");
            Console.WriteLine("Ingrese el nombre del producto cuyo precio desea actualizar:");
            Console.WriteLine("_--__--__--__--__--__--__--__--__--__--__--__--__--__--__--_\n");
            string nombreActualizar = Console.ReadLine();
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.WriteLine("_- Ingrese el nuevo precio:");
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            decimal nuevoPrecio;
            while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
            {
                Console.WriteLine("*****************************************************");
                Console.WriteLine("** Por favor, ingrese un precio válido y positivo. **");
                Console.WriteLine("*****************************************************\n");
            }
         
           


            Console.WriteLine("__--__--__--__--__--__--__--__--__--__--__--__--__--");
            Console.WriteLine("¿Desea eliminar un producto? (si/no)");
            Console.WriteLine("__--__--__--__--__--__--__--__--__--__--__--__--__--\n");
            string respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta == "si")
            {
                inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                Console.WriteLine("__--__--__--__--__--__--__--__--__--__--__--__--_-");
                Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
                Console.WriteLine("--__--__--__--__--__--__--__--__--__--__--__--__--");
                string nombreEliminar = Console.ReadLine();
                inventario.EliminarProducto(nombreEliminar);
                Console.WriteLine("Producto eliminado exitosamente.");
      
                inventario.ContarYAgruparProductosPorRango();
                inventario.GenerarReporteResumido();
                Console.WriteLine(">>----------------------------<<");
                Console.WriteLine("GRACIAS POR USAR NUESTRO SISTEMA");
                Console.WriteLine(">>----------------------------<<");
            }
            else
            {
                Console.WriteLine("************************************");
                Console.WriteLine("No se ha eliminado ningún producto..");
                Console.WriteLine("************************************\n");
                inventario.ContarYAgruparProductosPorRango();
                inventario.GenerarReporteResumido();
                Console.WriteLine(">>----------------------------<<");
                Console.WriteLine("GRACIAS POR USAR NUESTRO SISTEMA");
                Console.WriteLine(">>----------------------------<<");
            }

        }
    }
}