// Clase que representa un vaso de café
public class Vaso
{
    public int Onzas  { get; set; }
    public int Azucar { get; set; }
    public bool Listo { get; set; }
}

// Clase que representa el inventario de la máquina de café
public class Inventario
{
    public int Vasos  { get; private set; }
    public int Cafe   { get; private set; }
    public int Azucar { get; private set; }

    // Metodo para inicializar el inventario con valores predeterminados
    public Inventario(int vasos = 10, int cafe = 10, int azucar = 20)
    {
        Vasos  = vasos;
        Cafe   = cafe;
        Azucar = azucar;
    }

    // Metodos para descontar los recursos del inventario
    public bool DescontarVaso()
    {
        if (Vasos <= 0) return false;
        Vasos--;
        return true;
    }

    // Metodos para descontar los recursos del inventario
    public bool DescontarCafe()
    {
        if (Cafe <= 0) return false;
        Cafe--;
        return true;
    }

    // Metodos para descontar los recursos del inventario
    public bool DescontarAzucar(int cucharadas)
    {
        if (cucharadas > Azucar) return false;
        Azucar -= cucharadas;
        return true;
    }
}

// Clase principal de la máquina de café
public class MaquinaCafe
{
    private readonly Inventario _inventario;
    private string _mensaje = "";

    public int StockVasos  => _inventario.Vasos;
    public int StockCafe   => _inventario.Cafe;
    public int StockAzucar => _inventario.Azucar;

    private static readonly Dictionary<string, int> _tamanos = new()
    {
        // Tamaños de vasos y sus respectivas onzas
        { "Pequeno", 3 },
        { "Mediano", 5 },
        { "Grande",  7 }
    };

    // Metodo para inicializar la máquina de café con un inventario predeterminado
    public MaquinaCafe(int stockVasos = 10, int stockCafe = 10, int stockAzucar = 20)
    {
        _inventario = new Inventario(stockVasos, stockCafe, stockAzucar);
    }

    // Metodo para seleccionar un vaso de café según el tamaño deseado
    public Vaso SeleccionarVaso(string tamano)
    {
        if (!_inventario.DescontarVaso()) { _mensaje = "No hay vasos disponibles"; return new Vaso(); }
        if (!_inventario.DescontarCafe()) { _mensaje = "No hay café disponible";   return new Vaso(); }
        return new Vaso { Onzas = _tamanos[tamano] };
    }

    // Metodo para agregar azúcar al vaso de café
    public void AgregarAzucar(Vaso vaso, int cucharadas)
    {
        if (!_inventario.DescontarAzucar(cucharadas))
            _mensaje = "No hay azúcar disponible";
        else
            vaso.Azucar = cucharadas;
    }

    // Metodo para recoger el vaso de café una vez que está listo
    public Vaso RecogerVaso(Vaso vaso)
    {
        vaso.Listo = true;
        return vaso;
    }

    public string ObtenerMensaje() => _mensaje;
}
