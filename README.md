# Proyecto CRUD de Personas (React + .NET API)

Este proyecto implementa un **CRUD de personas** con dos formularios en React y un backend en .NET.

## Funcionalidades

- **Formulario A**: captura datos personales básicos y los conecta al backend (API).
- **Formulario B**: gestiona datos extendidos, almacenados en el state local.
- **Listado consolidado**: muestra personas de ambos formularios y permite búsqueda por nombre.
- **CRUD completo**:
  - Crear
  - Listar
  - Editar
  - Eliminar  
  Personas tanto del Formulario A (API) como del Formulario B (state local).

## Requisitos previos

- [Node.js](https://nodejs.org/) (versión 18 o superior)
- npm (incluido con Node.js)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

## Estructura del proyecto
- /PersonsApi      → Backend en .NET (API REST)
- /frontend        → Frontend en React (Vite)

## Instalación

### 1. Backend (.NET API)

```
cd PersonsApi
dotnet restore
dotnet run
```

- La API se levantará en: http://localhost:5018
- Swagger disponible en: http://localhost:5018/swagger

### 2. Frontend (React con Vite)
```
cd frontend
npm install
npm run dev
```
- El frontend se levantará en: http://localhost:5173

### Dependencias principales
## Backend
- Microsoft.AspNetCore.OpenApi → soporte Swagger/OpenAPI
- Swashbuckle.AspNetCore → documentación interactiva de la API

## Frontend
- react y react-dom → librerías base de React
- react-router-dom → manejo de rutas/páginas
- vite → bundler y servidor de desarrollo
