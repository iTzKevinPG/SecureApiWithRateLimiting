# 🚀 **SecureApiWithRateLimiting**  
Una API segura y escalable con implementación avanzada de seguridad, Rate Limiting y Throttling.

---

## 🌟 **Descripción General**  
Este proyecto utiliza **.NET Core** con **Entity Framework Core** para crear una API RESTful estructurada bajo principios de **Arquitectura Limpia**. Se implementaron prácticas avanzadas de seguridad como **JWT**, encriptación de contraseñas, y limitación de solicitudes para proteger la API y garantizar su rendimiento.

---

## 🛠️ **Tecnologías y Librerías Utilizadas**

- **Framework**: .NET 6/7 (LTS)  
- **ORM**: Entity Framework Core  
- **Seguridad**:  
  - Autenticación con JSON Web Tokens (JWT).  
  - Encriptación de contraseñas con SHA-256.  
  - Autorización basada en roles.  
- **Rate Limiting & Throttling**: Middleware personalizado.  
- **Documentación**: Swagger/OpenAPI.  

---

## 📊 **Arquitectura del Proyecto**

El proyecto sigue los principios de **Arquitectura Limpia**, dividiendo el código en capas claramente definidas:

```plaintext
SecureApiWithRateLimiting
├── Application
│   ├── DTOs
│   ├── Interfaces
│   │   └── IUserService.cs
│   ├── Services
│       └── UserService.cs
├── Domain
│   ├── Entities
│   │   └── User.cs
│   ├── Enums
│   └── Interfaces
│       └── IRepository.cs
├── Infrastructure
│   ├── Data
│   │   └── AppDbContext.cs
│   ├── Repository
│       └── UserRepository.cs
├── Migrations
│   ├── 20241210203615_InitialMigration.cs
│   └── AppDbContextModelSnapshot.cs
├── Presentation
│   ├── Configuration
│   │   ├── DependencyInjection.cs
│   │   ├── RateLimitingConfiguration.cs
│   │   └── SwaggerConfiguration.cs
│   ├── Controllers
│   │   ├── AuthController.cs
│   │   └── UserController.cs
│   ├── Middleware
│       └── RoleMiddleware.cs
├── Tests
│   ├── Results
│   ├── RateLimiting_Test_Report.md
│   └── SecureApiWithRateLimiting.postman_collection.json
├── appsettings.json
└── Program.cs
```

---

### 🌟 **Ventajas de esta Arquitectura**
- **Escalabilidad**: Facilita agregar nuevas funcionalidades sin romper el diseño existente.  
- **Pruebas Unitarias**: Se pueden probar componentes por separado.  
- **Mantenibilidad**: Promueve el desacoplamiento y la separación de responsabilidades.  

---

## ⚡ **Fases del Proyecto**

### **Fase 1: Conceptos Técnicos y Base del Proyecto**
1. **Versiones de .NET**: 
   - Utilizamos .NET 6/7 por ser versiones con soporte a largo plazo (LTS).  
2. **Entity Framework Core (EF Core)**:
   - Simplifica el acceso a bases de datos con migraciones y modelos.  
3. **Arquitectura Limpia**:
   - Separación en capas: Aplicación, Infraestructura, Dominio y Presentación.  

---

### **Fase 2: Desarrollo del Proyecto**

#### 🛠️ **Paso 1: Configuración del Proyecto**
- Configuración inicial con EF Core y base de datos local (SQL Server).  
- Migraciones generadas automáticamente para la persistencia de datos.  

#### 🔒 **Paso 2: Implementación de Seguridad Avanzada**
- **JWT** para autenticación segura y autorización por roles (Admin/Usuario).  
- Contraseñas encriptadas con SHA-256.  

#### 🛑 **Paso 3: Rate Limiting y Throttling**
- **Rate Limiting**:
  - Control de solicitudes por minuto para evitar abuso (límite bajo, medio y alto).
- **Throttling**:
  - Límite de velocidad: Máximo 1 solicitud cada 500ms.  

---

### **Fase 3: Pulir y Optimizar**
- **Refactorización**: Seguimos principios **SOLID** para mejorar el diseño del código.  
- **Documentación**: Swagger/OpenAPI para probar y explorar los endpoints.  
- **Pruebas**: Simulaciones en Postman para validar seguridad y límites.  

---

## 🔐 **Impacto del Proyecto**

1. **Protección de Datos**:
   - Evitamos accesos no autorizados con autenticación robusta y autorizaciones por rol.  
2. **Estabilidad del Sistema**:
   - El Rate Limiting previene la sobrecarga del servidor y asegura su rendimiento.  
3. **Experiencia del Usuario**:
   - Un servicio seguro y eficiente que garantiza la confiabilidad para los usuarios legítimos.  

---

## 🌐 **Cómo Ejecutar el Proyecto**

### 💻 **Requisitos**
- **SDK**: .NET 6/7 instalado en tu máquina.  
- **Base de datos**: SQL Server (local o en Docker).  

### ⚙️ **Instrucciones**
1. Clona este repositorio:  
   ```bash
   git clone https://github.com/iTzKevinPG/SecureApiWithRateLimiting.git
   cd SecureApiWithRateLimiting
   ```
2. Restaura las dependencias:  
   ```bash
   dotnet restore
   ```
3. Aplica las migraciones a la base de datos:  
   ```bash
   dotnet ef database update
   ```
4. Ejecuta la aplicación:  
   ```bash
   dotnet run
   ```
5. Accede a Swagger para probar la API:  
   - URL: `http://localhost:5182/swagger`

---

## 📓 **Endpoints Clave**

- **Login**:
  - `POST /api/auth/login`  
  - Headers: `{ "Content-Type": "application/json" }`  
  - Body:
    ```json
    {
        "username": "admin",
        "password": "Admin123."
    }
    ```
  - Política aplicada: `LowRate`. 

---

## ✨ **Contribuciones**

¡Este proyecto es una base sólida para explorar más conceptos de seguridad y escalabilidad en APIs modernas! Si quieres contribuir, crea un Pull Request o abre un Issue.  

---

## 🏆 **Agradecimientos**

Gracias por ser parte de este aprendizaje continuo. Este proyecto fue diseñado como una herramienta educativa para comprender y aplicar conceptos avanzados en .NET.  

¡Espero tus comentarios y sugerencias! 🚀😊  
