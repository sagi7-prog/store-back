# StoreSolution (Backend)

Proyecto backend en .NET 6.0 para la tienda.

## 🖥️ **Requisitos para Ubuntu 24.04.3 LTS**

- .NET 6.0 SDK o superior
- SQL Server para Linux
- Git

## 🚀 **Instalación y Configuración**

### 1. **Instalar .NET SDK (si no lo tienes)**

```bash
# Agregar el repositorio de Microsoft
wget https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Instalar .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0
```

### 2. **Clonar y configurar el proyecto**

```bash
git clone https://github.com/sagi7-prog/store-back.git
cd store-back
dotnet restore
dotnet build
```

## 🗄️ **Configuración de Base de Datos**

### **SQL Server para Linux (Recomendado)**

1. **Instalar SQL Server:**
```bash
# Importar la clave GPG pública
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -

# Registrar el repositorio de SQL Server
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/24.04/mssql-server-2022.list)"

# Instalar SQL Server
sudo apt-get update
sudo apt-get install -y mssql-server

# Configurar SQL Server
sudo /opt/mssql/bin/mssql-conf setup
```

2. **Instalar herramientas de SQL Server:**
```bash
sudo apt-get install -y mssql-tools unixodbc-dev
echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
source ~/.bashrc
```

3. **Crear la base de datos:**
```bash
sqlcmd -S localhost -U SA -P TuContraseña -C -i StoreDB.sql
```

### **Configuración de Conexión**

El archivo `Store.Front/appsettings.json` debe contener:

```json
{
  "ConnectionStrings": {
    "StoreSolution": "Server=localhost;Database=StoreDB;User Id=sa;Password=TuContraseña;TrustServerCertificate=true"
  }
}
```

**⚠️ IMPORTANTE:** Reemplaza `TuContraseña` con la contraseña real de tu usuario SA.

## 🏃‍♂️ **Ejecutar el Proyecto**

### 1. **Navegar al proyecto principal:**
```bash
cd Store.Front
```

### 2. **Ejecutar:**
```bash
dotnet run
```

### 3. **Acceder a la aplicación:**
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`
- **Swagger UI:** `http://localhost:5000/swagger`

## 🔐 **Usuario de Prueba**

El proyecto incluye un usuario de prueba:
- **Email:** `carlos.perez@example.com`
- **Password:** `123456`

## 🏗️ **Estructura del Proyecto**

- **Store.Front:** API Web principal (Controladores, Configuración)
- **Store.Business:** Lógica de negocio (Servicios)
- **Store.Data:** Acceso a datos (Repositorios, Contexto)
- **Store.Entities:** Modelos y DTOs

## 📡 **Endpoints Principales**

- **Autenticación:** `/api/auth/login`
- **Artículos:** `/api/articles`
- **Clientes:** `/api/customers`
- **Tiendas:** `/api/stores`
- **Carrito:** `/api/cart`

## 🔧 **Solución de Problemas**

### **Error de OpenSSL:**
Si encuentras "No usable version of libssl was found":
```bash
sudo apt-get install -y libssl-dev
```

### **Puerto en uso:**
Si los puertos 5000/5001 están ocupados:
```bash
sudo ss -tlnp | grep :500
sudo kill -9 [PID]
```

### **Problemas de conexión a SQL Server:**
```bash
# Verificar estado
sudo systemctl status mssql-server

# Reiniciar si es necesario
sudo systemctl restart mssql-server
```

## 📚 **Notas Importantes**

- ✅ El proyecto está actualizado a .NET 6.0 para compatibilidad con Ubuntu 24.04
- ✅ Swagger está configurado en `/swagger` (no como página principal)
- ✅ La autenticación JWT está configurada y funcionando
- ✅ CORS está habilitado para desarrollo local
- ✅ La base de datos incluye datos de prueba

## 🌐 **Desarrollo Frontend**

Para conectar con Angular o React:
- **URL Base:** `http://localhost:5000`
- **CORS:** Habilitado para `http://localhost:4200`

## 📞 **Soporte**

Si encuentras problemas:
1. Verifica que .NET 6.0 esté instalado: `dotnet --version`
2. Verifica que SQL Server esté ejecutándose
3. Revisa los logs de la aplicación
4. Asegúrate de que los puertos 5000 y 5001 estén disponibles
