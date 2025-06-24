# 🧠 LifeSync

**LifeSync** es una API RESTful desarrollada en **ASP.NET Core** que actúa como un asistente inteligente de organización personal. Permite a los usuarios gestionar rutinas diarias, tareas personalizadas, habilidades culinarias y alergias alimentarias. Está preparada para futuras integraciones con IA que generen planes diarios y menús semanales personalizados.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core + SQLite
- JWT Authentication
- Swagger (Swashbuckle)
- Arquitectura por capas: API / Application / Domain / Infrastructure

---

## 📦 Estructura del proyecto

LifeSync/
│
├── LifeSync.API ← Punto de entrada de la API
├── LifeSync.Application ← Interfaces, DTOs, servicios abstractos
├── LifeSync.Domain ← Entidades principales del modelo de negocio
├── LifeSync.Infrastructure ← DbContext, repositorios e implementación de servicios

---

## ✅ Funcionalidades principales

- 🔐 Registro y login de usuarios con tokens JWT
- 👤 Gestión de preferencias personales:
  - Alergias alimentarias
  - Habilidades culinarias
- 🗓️ Creación y consulta de rutinas por fecha
- ✅ Añadir tareas a rutinas
- 🔍 Swagger UI para probar todos los endpoints

---

## ▶️ Cómo ejecutar el proyecto

1. **Clona el repositorio**


git clone https://github.com/tu_usuario/LifeSync.git
cd LifeSync

2. **Aplica las migraciones y crea la base de datos**

dotnet ef database update --project LifeSync.Infrastructure --startup-project LifeSync.API

3. **Ejecuta la API**

dotnet run --project LifeSync.API

4. **Abre Swagger en tu navegador**

http://localhost:5057/swagger

🔐 Prueba de autenticación
1. Llama a POST /api/auth/register para crear un usuario

2. Llama a POST /api/auth/login y copia el token

3. Haz clic en "Authorize" y pega:

Bearer ey...

4. Ya puedes acceder a los endpoints protegidos (/api/profile, /api/routines, etc.)

📚 Próximas funcionalidades (roadmap)
 Generación automática de planificación diaria

 Generador de menús semanales personalizado

 Sistema de hábitos y seguimiento

 Sistema de prioridades y recordatorios inteligentes

 Exportación del plan del día a PDF o app frontend

👨‍💻 Autor
Desarrollado por Alejandro Guerra, ingeniero de telecomunicación y programador backend.

📬 Contacto: [alexguerran2002@gmail.com]
🔗 Linkedin: [https://www.linkedin.com/in/alejandro-guerra-nogueira-269063218/]
