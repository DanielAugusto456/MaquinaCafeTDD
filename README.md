# MaquinaCafeTDD

Práctica de **Test-Driven Development (TDD)** — Ingeniería de Software | ITLA

## ¿Qué es TDD?

TDD es una metodología donde el programador escribe la prueba **antes** de escribir el código. El proceso se repite en ciclos cortos hasta implementar toda la funcionalidad.

## Ciclo Red → Green → Refactor

| Fase | Descripción |
|------|-------------|
| RED | Escribir la prueba que **falla** (el código aún no existe) |
| GREEN | Escribir el código **mínimo** para que la prueba pase |
| REFACTOR | Mejorar el diseño sin romper las pruebas |

## Estructura del proyecto

```
MaquinaCafeTDD/
├── MaquinaCafe/               # Proyecto principal
│   └── MaquinaCafe.cs         # Lógica de la máquina
├── MaquinaCafe.Tests/         # Proyecto de pruebas
│   └── MaquinaCafeTests.cs    # 8 casos de prueba (TC-01 al TC-08)
└── MaquinaCafeTDD.sln
```

## Casos de prueba

| ID | Escenario | Assert |
|----|-----------|--------|
| TC-01 | Insertar monedas acumula saldo | `Saldo == 25` |
| TC-02 | Saldo suficiente → bebida dispensada | `true` |
| TC-03 | Saldo insuficiente → rechazado | `false` |
| TC-04 | Devolver cambio correcto | `ObtenerCambio() == 50` |
| TC-05 | Bebida inexistente → excepción | `ArgumentException` |
| TC-06 | Menú con 3 bebidas y precios | `Count == 3` |
| TC-07 | Devolver monedas reinicia saldo | `Saldo == 0` |
| TC-08 | Sin stock → no dispensa | `false` |

## Cómo ejecutar las pruebas

```bash
dotnet restore
dotnet test
```

O en Visual Studio: **Test → Run All Tests** (`Ctrl+R, A`)

## Historial de commits

- ` agregar 8 casos de prueba TDD - fase RED`
- ` implementación mínima para pasar los tests - fase GREEN`
- `refactor: REFACTOR`

## Repositorio de gitHub
https://github.com/DanielAugusto456/MaquinaCafeTDD