using NUnit.Framework;

[TestFixture]
public class MaquinaCafeTests
{
    private MaquinaCafe _maquina = null!;

    [SetUp]
    public void Inicializar() => _maquina = new MaquinaCafe();

    // TEST-01: Seleccionar vaso pequeño dispensa 3 oz
    [Test]
    public void SeleccionarVaso_Pequeno_Dispensa3Oz()
    {
        var resultado = _maquina.SeleccionarVaso("Pequeno");
        Assert.AreEqual(3, resultado.Onzas);
    }

    // TEST-02: Seleccionar vaso mediano dispensa 5 oz
    [Test]
    public void SeleccionarVaso_Mediano_Dispensa5Oz()
    {
        var resultado = _maquina.SeleccionarVaso("Mediano");
        Assert.AreEqual(5, resultado.Onzas);
    }

    // TEST-03: Seleccionar vaso grande dispensa 7 oz
    [Test]
    public void SeleccionarVaso_Grande_Dispensa7Oz()
    {
        var resultado = _maquina.SeleccionarVaso("Grande");
        Assert.AreEqual(7, resultado.Onzas);
    }

    // TEST-04: Seleccionar azucar agrega cucharadas al vaso
    [Test]
    public void AgregarAzucar_AgregaCucharadas()
    {
        var vaso = _maquina.SeleccionarVaso("Mediano");
        _maquina.AgregarAzucar(vaso, 2);
        Assert.AreEqual(2, vaso.Azucar);
    }

    // TEST-05: Recoger vaso retorna el vaso preparado listo
    [Test]
    public void RecogerVaso_RetornaVasoListo()
    {
        var vaso = _maquina.SeleccionarVaso("Grande");
        _maquina.AgregarAzucar(vaso, 1);
        var vasoFinal = _maquina.RecogerVaso(vaso);
        Assert.IsTrue(vasoFinal.Listo);
    }

    // TEST-06: Sin vasos disponibles muestra mensaje
    [Test]
    public void SeleccionarVaso_SinStock_RetornaMensaje()
    {
        int stockInicial = _maquina.StockVasos;
        for (int i = 0; i < stockInicial; i++)
            _maquina.SeleccionarVaso("Pequeno");

        // Llamada extra que debe disparar el mensaje
        _maquina.SeleccionarVaso("Pequeno");

        Assert.AreEqual("No hay vasos disponibles", _maquina.ObtenerMensaje());
    }

    // TEST-07: Sin cafe disponible muestra mensaje
    [Test]
    public void SeleccionarVaso_SinCafe_RetornaMensaje()
    {
        // Mas vasos que cafe para que falle por cafe primero
        var maquina = new MaquinaCafe(stockVasos: 20, stockCafe: 5);
        for (int i = 0; i < 5; i++)
            maquina.SeleccionarVaso("Grande");

        // Llamada extra que debe disparar el mensaje de cafe
        maquina.SeleccionarVaso("Grande");

        Assert.AreEqual("No hay café disponible", maquina.ObtenerMensaje());
    }

    // TEST-08: Sin azucar disponible muestra mensaje
    [Test]
    public void AgregarAzucar_SinStock_RetornaMensaje()
    {
        var vaso = _maquina.SeleccionarVaso("Pequeno");
        _maquina.AgregarAzucar(vaso, _maquina.StockAzucar + 1);

        Assert.AreEqual("No hay azúcar disponible", _maquina.ObtenerMensaje());
    }
}
