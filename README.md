# ApiEcommerce

Mi primera API REST construida con ASP.NET Core y .NET 10. El proyecto es un ecommerce básico que por ahora gestiona categorías de productos.

## Tecnologías

- **.NET 10** con ASP.NET Core
- **Entity Framework Core 10** para el acceso a la base de datos
- **SQL Server 2022** como base de datos (containerizada con Docker)
- **Mapperly** para el mapeo entre entidades y DTOs (generación en tiempo de compilación)
- **Scalar** para la documentación interactiva de la API
- **DotNetEnv** para manejo de variables de entorno

## Estructura del proyecto

```
ApiEcommerce/
├── Controllers/        # Endpoints de la API
├── Models/             # Entidades y DTOs
│   └── Dtos/
├── Repository/         # Patrón repositorio (interfaces + implementaciones)
├── Mapping/            # Mappers generados con Mapperly
├── Data/               # DbContext de Entity Framework
└── Migrations/         # Migraciones de la base de datos
```

## Endpoints disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/categories` | Lista todas las categorías |
| GET | `/api/categories/{id}` | Obtiene una categoría por ID |
| POST | `/api/categories` | Crea una nueva categoría |
| PATCH | `/api/categories/{id}` | Actualiza el nombre de una categoría |

## Cómo correr el proyecto

### 1. Levantar la base de datos

```bash
docker-compose up -d
```

### 2. Configurar variables de entorno

Crear un archivo `.env` en la raíz con:

```
SA_PASSWORD=TuPasswordAqui
```

### 3. Aplicar migraciones

```bash
dotnet ef database update
```

### 4. Correr la API

```bash
dotnet run
```

La documentación interactiva estará disponible en `/scalar`.

## Conceptos aplicados

- Patrón repositorio con interfaces (`ICategoryRepository`)
- DTOs para separar la capa de transporte del modelo de datos
- Mapeo con source generators (Mapperly) en lugar de reflection
- Change tracking de Entity Framework Core
- Contenedorización de la base de datos con Docker
