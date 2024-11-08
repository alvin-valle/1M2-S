using Gestión_de_Inventario_de_Productos;

public class Inventario
{
    private List<Producto> productos;

    public Inventario()
    {
        productos = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            Console.WriteLine($"El precio del producto: {nombre} ha sido actualizado a {nuevoPrecio:C}");
        }
        else
        {
            Console.WriteLine("***********************");
            Console.WriteLine("Producto no encontrado.");
            Console.WriteLine("***********************\n");
        }
    }

    public void EliminarProducto(string nombre)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            productos.Remove(producto);
            Console.WriteLine($"El producto '{nombre}' ha sido eliminado.");
        }
        else
        {
            Console.WriteLine("***********************");
            Console.WriteLine("Producto no encontrado.");
            Console.WriteLine("***********************\n");
        }
    }

    public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
    {
        return productos
            .Where(p => p.Precio > precioMinimo)
            .OrderBy(p => p.Precio);
    }

    public void ContarYAgruparProductosPorRango()
    {
        var grupos = productos.GroupBy(p =>
        {
            if (p.Precio < 100) return "Menor a 100";
            else if (p.Precio >= 100 && p.Precio <= 500) return "Entre 100 y 500";
            else return "Mayor a 500";
        });

        Console.WriteLine("\nConteo de productos por rango de precio:");
        foreach (var grupo in grupos)
        {
            Console.WriteLine($"{grupo.Key}: {grupo.Count()} productos");
        }
    }
    public void GenerarReporteResumido()
    {
        int totalProductos = productos.Count;

        decimal precioPromedio = productos.Any() ? productos.Average(p => p.Precio) : 0;

        var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
        var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();

        Console.WriteLine("__--__--__--__--__--__--__--__--");
        Console.WriteLine("Reporte Resumido del Inventario:");
        Console.WriteLine("__--__--__--__--__--__--__--__--\n");
        Console.WriteLine($"Total de productos: {totalProductos}\n");
        Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}\n");

        if (productoMasCaro != null && productoMasBarato != null)
        {
            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre} - {productoMasCaro.Precio:C}");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre} - {productoMasBarato.Precio:C}");
        }
        else
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("No hay productos en el inventario.");
            Console.WriteLine("**********************************");
        }
    }
}

