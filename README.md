# Acceso a Datos

## Descripción

Acceso a Datos es un proyecto de desarrollo de software que integra una API y una aplicación web para la gestión de información mediante una base de datos.

El proyecto está organizado en dos componentes principales: `APIDataAccess`, encargado de la comunicación con los datos, y `MelodyInventario`, que contiene la aplicación web para interactuar con el sistema.

## Tecnologías utilizadas

- C# 
- .NET
- Blazor
- ASP.NET Core Web API
- PostgreSQL
- Entity Framework Core

## Estructura del proyecto

```text
Acceso a Datos/
│
├── APIDataAccess/
│   └── API encargada del acceso a los datos
│
├── MelodyInventario/
│   └── Aplicación web de inventario
│
└── .gitignore
```

## Características generales

- Comunicación entre la aplicación web y la API.
- Acceso a información almacenada en PostgreSQL.
- Organización del proyecto en componentes independientes.
- Gestión de información mediante tecnologías de .NET.

## Requisitos

- Visual Studio o Visual Studio Code.
- SDK de .NET compatible con los proyectos.
- PostgreSQL.
- Acceso a la base de datos utilizada por la aplicación.

## Instalación

1. Clonar el repositorio:

```bash
git clone URL_DEL_REPOSITORIO
```

2. Entrar a la carpeta del proyecto:

```bash
cd "Acceso a Datos"
```

3. Restaurar las dependencias:

```bash
dotnet restore
```

4. Configurar la conexión a PostgreSQL en el entorno local.

5. Ejecutar los proyectos correspondientes.

## Configuración de la base de datos

La API utiliza una cadena de conexión para comunicarse con PostgreSQL.

La configuración local se encuentra en los archivos de configuración de la API, pero estos no se incluyen en el repositorio para proteger las credenciales.

Cada usuario debe configurar su propia conexión antes de ejecutar el proyecto.

## Seguridad

- Los archivos `appsettings.json` están excluidos mediante `.gitignore`.
- No se deben publicar contraseñas, cadenas de conexión ni credenciales privadas.
- Las configuraciones sensibles deben mantenerse únicamente en el entorno local.

## Autor

Proyecto académico - Acceso a Datos.