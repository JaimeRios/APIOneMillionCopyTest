# 📦 Project Name: One Million Copy Test Api

Brief description of the API.  
 *REST API desarrollada en .NET 8 para la prueba de la empresa One Million Copy S.A.S* 

---

## 🚀 Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL Creado en la web AIVEN: https://console.aiven.io/login 
- Swagger 
- Servicio mockeado para IA

---

## 📂 Project Structure

```bash
src/
│
├── API/
│   ├── Controllers/
│   ├── Filters/
│
├── Application/
│   ├── DTOs/
│   └── Services/
│
├── Domain/
│   ├── Entities/
│   ├── Enums/
│   └── Exceptions/
│
└──Infrastructure/
    ├── Persintence/
    └── Repositories/

```

---

## ⚙️ Configuration
Abrir Archivo appsettings y copiar la cadena de conexion a la base de datos

### Prerequisites

- .NET SDK 8.0 or higher
- Visual Studio 2022 or VS Code
- Base de datos PostgreSQL 

---

### Environment Variables

Example configuration in `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "PostgreSQL_StringConnection"
  },
  "OpenAI": {
    "ApiKey": "TU_API_KEY"
  },
  "AllowedHosts": "*"
}
```

---

## ▶️ Running the Project
Para probar en local siga los siguientes pasos
1. Descargar visual studio 2022 o una version superior e instale con version .net 8
2. Clonar el repositorio:  
   * Tener instalado git para windows 
   * Abrir una consola y ejecuta el comando git clone https://github.com/JaimeRios/APIOneMillionCopyTest.git
   * Moverse a la rama develop git checkout -b develop
3. Abrir la carpeta clonada y buscar APIOneMillionCopyTest.sln para abrir el proyecto
4. Una vez abirto el proyecto clic derecho sobre la solucion y buscar la opcion restaurar paquetes nuget o Restore NuGet Packages
5. Compilar y correr proyecto seleccionando la flecha verde en la barra de opcion o en el Menu Debug -> Start Debugging

### From the command line

```bash
dotnet restore
dotnet build
dotnet run
```

The API will be available at:

```
https://localhost:7257/swagger/index.html
http://localhost:7257/swagger/index.html
```

---

## 📖 API Documentation (Swagger)

Swagger is enabled by default.

```
https://localhost:7257/swagger/index.html
```

From there you can:
- View available endpoints
- Test requests
- Review request and response models

---

## 📌 Endpoints

Example:

| Method | Endpoint          | Description                                                                          |
|--------|-------------------|--------------------------------------------------------------------------------------|
| GET    | /leads            | Obtiene leads con filtrado de informacion paginada y filtrada por la fuente del lead |
| GET    | /leads/:id        | Obtiene un lead por su id                                                            |
| PATCH  | /leads/:id        | Actualiza la informacion de un lead                                                  |
| DELETE | /leads/:id        | Elimina un lead usando su id                                                         |
| GET    | /leads/stats      | Obtiene informacion general de todos los leads                                       |
| GET    | /leads/ai/summary | Envia los leads que cumplen condiciones de fuente en un rango de fechas              |

---

## 🧪 Testing

Run unit tests:

```bash
dotnet test
```

---

## 📦 Publishing

```bash
dotnet publish -c Release
```

The output will be generated at:

```
bin/Release/net8.0/publish
```

---

## 🛠 Best Practices

- Use DTOs for input/output
- Global error handling
- Validation with DataAnnotations or FluentValidation
- Layered architecture

---

## 📄 License

This project is licensed under the **MIT License** (or applicable license).

---

## ✍️ Author

- Name : Jaime Rios
- Email : jaimearios1986@gmail.com
- GitHub : https://github.com/JaimeRios 
- LinkedIn: https://www.linkedin.com/in/jaime-alberto-rios-palacio/
