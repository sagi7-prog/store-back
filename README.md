# StoreSolution (Backend)

Proyecto backend en .NET Core 3.1 para la tienda.

## Requisitos

- .NET Core SDK 3.1
- SQL Server
- Visual Studio 2019 o superior
- Git

## Configuración

1. Clonar el repositorio:

```bash
git clone https://github.com/sagi7-prog/store-back.git

cd store-back

2. Restaurar paquetes:

dotnet restore

3. Configurar la cadena de conexión en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=StoreDB;Trusted_Connection=True;"
}

4. Crear la base de datos usando el script StoreDB.sql.

5. Ejecutar el proyecto:

dotnet run
