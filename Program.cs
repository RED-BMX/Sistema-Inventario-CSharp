Inventario inventario = new Inventario(new PersistenciaSQLite());

Menu menu = new Menu(inventario);

menu.Ejecutar();