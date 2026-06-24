// ============================================================
// FASE GREEN - Implementacion minima para pasar los tests
// ============================================================

public class Vaso
{
    public int Onzas { get; set; }
    public int Azucar { get; set; }
    public bool Listo { get; set; }
}

public class MaquinaCafe
{
    public int StockVasos  { get; private set; }
    public int StockCafe   { get; private set; }
    public int StockAzucar { get; private set; }

    private string _mensaje = "";

    public MaquinaCafe(int stockVasos = 10, int stockCafe = 10, int stockAzucar = 20)
    {
        StockVasos  = stockVasos;
        StockCafe   = stockCafe;
        StockAzucar = stockAzucar;
    }

    private static readonly Dictionary<string, int> _tamanos = new()
    {
        { "Pequeno", 3 },
        { "Mediano", 5 },
        { "Grande",  7 }
    };

    public Vaso SeleccionarVaso(string tamano)
    {
        if (StockVasos <= 0) { _mensaje = "No hay vasos disponibles"; return new Vaso(); }
        if (StockCafe  <= 0) { _mensaje = "No hay café disponible";   return new Vaso(); }

        StockVasos--;
        StockCafe--;
        return new Vaso { Onzas = _tamanos[tamano] };
    }

    public void AgregarAzucar(Vaso vaso, int cucharadas)
    {
        if (cucharadas > StockAzucar) { _mensaje = "No hay azúcar disponible"; return; }
        StockAzucar -= cucharadas;
        vaso.Azucar = cucharadas;
    }

    public Vaso RecogerVaso(Vaso vaso)
    {
        vaso.Listo = true;
        return vaso;
    }

    public string ObtenerMensaje() => _mensaje;
}
