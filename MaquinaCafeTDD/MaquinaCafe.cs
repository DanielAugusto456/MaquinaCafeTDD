public class Vaso
{
    public int Onzas  { get; set; }
    public int Azucar { get; set; }
    public bool Listo { get; set; }
}

public class Inventario
{
    public int Vasos  { get; private set; }
    public int Cafe   { get; private set; }
    public int Azucar { get; private set; }

    public Inventario(int vasos = 10, int cafe = 10, int azucar = 20)
    {
        Vasos  = vasos;
        Cafe   = cafe;
        Azucar = azucar;
    }

    public bool DescontarVaso()
    {
        if (Vasos <= 0) return false;
        Vasos--;
        return true;
    }

    public bool DescontarCafe()
    {
        if (Cafe <= 0) return false;
        Cafe--;
        return true;
    }

    public bool DescontarAzucar(int cucharadas)
    {
        if (cucharadas > Azucar) return false;
        Azucar -= cucharadas;
        return true;
    }
}

public class MaquinaCafe
{
    private readonly Inventario _inventario;
    private string _mensaje = "";

    public int StockVasos  => _inventario.Vasos;
    public int StockCafe   => _inventario.Cafe;
    public int StockAzucar => _inventario.Azucar;

    private static readonly Dictionary<string, int> _tamanos = new()
    {
        { "Pequeno", 3 },
        { "Mediano", 5 },
        { "Grande",  7 }
    };

    public MaquinaCafe(int stockVasos = 10, int stockCafe = 10, int stockAzucar = 20)
    {
        _inventario = new Inventario(stockVasos, stockCafe, stockAzucar);
    }

    public Vaso SeleccionarVaso(string tamano)
    {
        if (!_inventario.DescontarVaso()) { _mensaje = "No hay vasos disponibles"; return new Vaso(); }
        if (!_inventario.DescontarCafe()) { _mensaje = "No hay café disponible";   return new Vaso(); }
        return new Vaso { Onzas = _tamanos[tamano] };
    }

    public void AgregarAzucar(Vaso vaso, int cucharadas)
    {
        if (!_inventario.DescontarAzucar(cucharadas))
            _mensaje = "No hay azúcar disponible";
        else
            vaso.Azucar = cucharadas;
    }

    public Vaso RecogerVaso(Vaso vaso)
    {
        vaso.Listo = true;
        return vaso;
    }

    public string ObtenerMensaje() => _mensaje;
}
