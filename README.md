# Sistema de Inventario en C#

Aplicación de consola desarrollada en **C# y .NET 8** para gestionar productos y controlar el inventario.

Este proyecto forma parte de mi portafolio de desarrollo de software y tiene como objetivo demostrar conocimientos en **programación orientada a objetos, colecciones, LINQ, persistencia de datos, pruebas unitarias, Entity Framework Core, Git y buenas prácticas de desarrollo**.

## Características

* Agregar productos.
* Eliminar productos.
* Buscar productos por ID.
* Mostrar todos los productos.
* Aumentar el stock.
* Reducir el stock.
* Validar IDs.
* Evitar IDs duplicados.
* Validar precios y cantidades.
* Evitar stock negativo.
* Manejar productos inexistentes.
* Manejar cantidades mayores al stock disponible.
* Persistencia de datos mediante JSON.
* Persistencia de datos mediante SQLite.
* Pruebas unitarias con xUnit.

## Tecnologías utilizadas

* **C#**
* **.NET 8**
* **Entity Framework Core 8**
* **SQLite**
* **xUnit**
* **LINQ**
* **Git**
* **GitHub**

## Persistencia de datos

El sistema utiliza la interfaz `IPersistencia` para abstraer el mecanismo utilizado para guardar y cargar los productos.

Actualmente existen dos implementaciones:

* `PersistenciaJson`: almacena los productos en un archivo `productos.json`.
* `PersistenciaSQLite`: almacena los productos en una base de datos SQLite mediante Entity Framework Core.

Esto permite cambiar el mecanismo de persistencia sin modificar la lógica principal del inventario.

## Pruebas unitarias

El proyecto incluye un proyecto independiente de pruebas:

```text
Sistema-Inventario-CSharp.Tests/
```

Las pruebas utilizan **xUnit** y una implementación `FakePersistencia` para probar la lógica del inventario sin modificar los archivos reales de persistencia.

Actualmente existen **12 pruebas unitarias**, que cubren operaciones como:

* Agregar productos.
* Evitar productos con IDs duplicados.
* Buscar productos existentes.
* Buscar productos inexistentes.
* Eliminar productos.
* Aumentar stock.
* Reducir stock.
* Validar cantidades inválidas.
* Evitar reducir más stock del disponible.
* Obtener todos los productos.

Para ejecutar las pruebas:

```bash
dotnet test Sistema-Inventario-CSharp.Tests
```

Resultado actual:

```text
12 pruebas superadas
0 errores
0 omitidas
```

## Ejecución del proyecto

Para compilar el proyecto:

```bash
dotnet build
```

Para ejecutar la aplicación:

```bash
dotnet run
```

## Estructura del proyecto

```text
Sistema-Inventario-CSharp/
├── Producto.cs
├── Inventario.cs
├── IPersistencia.cs
├── PersistenciaJson.cs
├── PersistenciaSQLite.cs
├── InventarioDbContext.cs
├── Menu.cs
├── Program.cs
├── productos.json
├── Sistema-Inventario-CSharp.Tests/
│   ├── FakePersistencia.cs
│   ├── GlobalUsings.cs
│   ├── Sistema-Inventario-CSharp.Tests.csproj
│   └── UnitTest1.cs
├── README.md
├── .gitignore
└── Sistema-Inventario-CSharp.csproj
```

## Arquitectura actual

El proyecto utiliza una separación básica de responsabilidades:

* `Producto`: representa la entidad producto y contiene las reglas relacionadas con sus datos y stock.
* `Inventario`: contiene la lógica principal para gestionar los productos.
* `IPersistencia`: define el contrato para guardar y cargar productos.
* `PersistenciaJson`: implementación de persistencia mediante JSON.
* `PersistenciaSQLite`: implementación de persistencia mediante SQLite.
* `InventarioDbContext`: contexto de Entity Framework Core para SQLite.
* `Menu`: gestiona la interacción con el usuario desde la consola.
* `Program`: configura e inicia la aplicación.

La utilización de `IPersistencia` permite desacoplar la lógica del inventario del mecanismo concreto de almacenamiento.

## Control de versiones

El desarrollo del proyecto utiliza **Git y GitHub**.

Las funcionalidades importantes se desarrollan mediante ramas independientes y posteriormente se integran a `main` mediante Pull Requests.

Ejemplos de funcionalidades desarrolladas:

* `feature/json-persistence`
* `feature/unit-tests`
* `feature/sqlite-persistence`

Este flujo permite mantener un historial de desarrollo organizado y facilita la revisión de cambios.

## Estado del proyecto

Actualmente el sistema cuenta con:

* Gestión básica de productos.
* Validaciones de datos.
* Persistencia JSON.
* Persistencia SQLite.
* Entity Framework Core.
* Pruebas unitarias con xUnit.
* 12 pruebas automatizadas.
* Control de versiones con Git.
* Integración mediante Pull Requests en GitHub.

El siguiente objetivo del proyecto es continuar evolucionando la arquitectura y posteriormente convertir la lógica del sistema en una **API REST con ASP.NET Core**.
