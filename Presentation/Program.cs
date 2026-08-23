using Sistema_Inventario_CSharp.Application;
using Sistema_Inventario_CSharp.Infrastructure;
using Sistema_Inventario_CSharp.Presentation;

Inventario inventario = new Inventario(new PersistenciaSQLite());

Menu menu = new Menu(inventario);

menu.Ejecutar();