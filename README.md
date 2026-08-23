# Sistema de Inventario en C#

Aplicación de consola desarrollada en **C# y .NET 8** para gestionar productos y controlar el inventario.

Este proyecto forma parte de mi portafolio de desarrollo de software y tiene como objetivo demostrar conocimientos en **programación orientada a objetos, colecciones, LINQ, persistencia de datos, pruebas unitarias, Entity Framework Core, arquitectura por capas, Git y buenas prácticas de desarrollo**.

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

## Arquitectura

El proyecto utiliza una estructura básica de **arquitectura por capas**, separando las responsabilidades principales del sistema.

```text
Presentation
      ↓
Application
      ↓
   Domain

Application
      ↓
IPersistencia
      ↑
Infrastructure
```

### Domain

Contiene las entidades y reglas fundamentales del dominio.

```text
Domain/
└── Producto.cs
```

`Producto` representa un producto del inventario y contiene las reglas relacionadas con sus datos y operaciones de stock.

### Application

Contiene la lógica principal del sistema y los contratos necesarios para la persistencia.

```text
Application/
├── Inventario.cs
└── IPersistencia.cs
```

`Inventario` gestiona las operaciones principales sobre los productos.

`IPersistencia` define el contrato que deben implementar los diferentes mecanismos de almacenamiento.

### Infrastructure

Contiene las implementaciones concretas relacionadas con la persistencia de datos.

```text
Infrastructure/
├── InventarioDbContext.cs
├── PersistenciaJson.cs
└── PersistenciaSQLite.cs
```

Actualmente existen dos mecanismos de persistencia:

* `PersistenciaJson`: almacena los productos en `productos.json`.
* `PersistenciaSQLite`: almacena los productos en una base de datos SQLite mediante Entity Framework Core.

Gracias a `IPersistencia`, la lógica principal del inventario no depende directamente de una implementación concreta de almacenamiento.

### Presentation

Contiene la interacción con el usuario y el punto de entrada de la aplicación.

```text
Presentation/
├── Menu.cs
└── Program.cs
```

`Menu` gestiona las opciones disponibles desde la consola.

`Program` configura la aplicación e inicia el sistema.

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

Las pruebas utilizan **xUnit** y una implementación `FakePersistencia` para probar la lógica del inventario sin depender directamente de SQLite o de archivos reales de persistencia.

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

### Compilar

```bash
dotnet build
```

### Ejecutar

```bash
dotnet run
```

### Ejecutar las pruebas

```bash
dotnet test Sistema-Inventario-CSharp.Tests
```

## Estructura del proyecto

```text
Sistema-Inventario-CSharp/
├── Domain/
│   └── Producto.cs
│
├── Application/
│   ├── Inventario.cs
│   └── IPersistencia.cs
│
├── Infrastructure/
│   ├── InventarioDbContext.cs
│   ├── PersistenciaJson.cs
│   └── PersistenciaSQLite.cs
│
├── Presentation/
│   ├── Menu.cs
│   └── Program.cs
│
├── Sistema-Inventario-CSharp.Tests/
│   ├── FakePersistencia.cs
│   ├── GlobalUsings.cs
│   ├── Sistema-Inventario-CSharp.Tests.csproj
│   └── UnitTest1.cs
│
├── productos.json
├── inventario.db
├── README.md
├── .gitignore
└── Sistema-Inventario-CSharp.csproj
```

## Control de versiones

El desarrollo del proyecto utiliza **Git y GitHub**.

Las funcionalidades importantes se desarrollan mediante ramas independientes y posteriormente se integran a `main` mediante Pull Requests.

Ejemplos de funcionalidades desarrolladas:

* `feature/json-persistence`
* `feature/unit-tests`
* `feature/sqlite-persistence`
* `feature/layered-architecture`

Este flujo permite mantener un historial de desarrollo organizado, separar funcionalidades y facilitar la revisión de cambios.

## Buenas prácticas aplicadas

Durante el desarrollo se aplicaron diferentes prácticas de desarrollo de software:

* Programación orientada a objetos.
* Encapsulamiento.
* Separación de responsabilidades.
* Arquitectura por capas.
* Abstracción mediante interfaces.
* Inyección de dependencias.
* Validación de datos.
* Persistencia desacoplada.
* Pruebas unitarias.
* Uso de LINQ.
* Control de versiones con Git.
* Desarrollo mediante ramas.
* Integración mediante Pull Requests.
* Documentación del proyecto.

## Estado del proyecto

El proyecto se encuentra en un estado **funcional y estable**.

Actualmente cuenta con:

* Gestión básica de productos.
* Validaciones de datos.
* Persistencia JSON.
* Persistencia SQLite.
* Entity Framework Core.
* Arquitectura organizada por capas.
* Pruebas unitarias con xUnit.
* **12 pruebas automatizadas.**
* Control de versiones con Git.
* Desarrollo mediante ramas y Pull Requests.
* Integración de cambios mediante Pull Requests en GitHub.

El proyecto cumple su objetivo como una aplicación de consola orientada a demostrar fundamentos de desarrollo de software, programación orientada a objetos, persistencia de datos, pruebas automatizadas, arquitectura por capas y buenas prácticas de control de versiones.
