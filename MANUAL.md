# Manual de uso de SNIC RD API

## Requisitos

- .NET 8 SDK.
- SQL Server accesible desde el equipo.
- La base de datos `SNIC_RD` creada y con el esquema requerido por la aplicación.

La conexión se configura en `appsettings.json`, bajo `ConnectionStrings:DefaultConnection`. Antes de iniciar, confirma que el valor de `Server` identifica tu instancia de SQL Server y que la base de datos existe. La configuración actual usa la instancia `MSI\SQLEXPRESS` y autenticación integrada de Windows.

## Cómo iniciar el proyecto

Abre PowerShell en la carpeta del proyecto y ejecuta:

```powershell
dotnet restore
$env:Jwt__Key = [Convert]::ToBase64String([Security.Cryptography.RandomNumberGenerator]::GetBytes(32))
dotnet run --launch-profile http
```

La aplicación requiere `Jwt__Key` como variable de entorno y exige una clave de al menos 32 bytes. No guardes esa clave en el repositorio. La configuración de desarrollo establece `Jwt:Issuer`, `Jwt:Audience` y una duración de 60 minutos; en otros entornos configura también esos valores mediante variables como `Jwt__Issuer`, `Jwt__Audience` y `Jwt__AccessTokenExpirationMinutes`.

El perfil `http` inicia la aplicación en `http://localhost:5004` y establece el entorno `Development`, que es donde Swagger está habilitado. Mantén abierta la terminal mientras uses la API. Para detenerla, presiona `Ctrl+C`.

También se puede usar el perfil HTTPS:

```powershell
dotnet run --launch-profile https
```

Este perfil usa `https://localhost:7181` y `http://localhost:5004`. Si el certificado de desarrollo no está instalado, el navegador puede mostrar una advertencia al abrir la dirección HTTPS.

## Cómo acceder a Swagger

Con el perfil HTTP, abre:

- Interfaz interactiva: [http://localhost:5004/swagger](http://localhost:5004/swagger)
- Documento OpenAPI en JSON: [http://localhost:5004/swagger/v1/swagger.json](http://localhost:5004/swagger/v1/swagger.json)

Swagger muestra las operaciones disponibles y permite probarlas desde el navegador. Si la página no abre, confirma que `dotnet run` sigue activo y que la aplicación está en el entorno `Development`.

## Autenticación

El endpoint `POST /api/Auth/login` no requiere token. Envía el correo y la contraseña de un usuario existente:

```json
{
  "correo": "usuario@example.com",
  "contrasena": "tu-contrasena"
}
```

Si las credenciales son correctas, la respuesta incluye `token` y `expiraEn`. En Swagger, pulsa **Authorize**, pega el token (sin escribir `Bearer`) y autoriza. Las operaciones de la API requieren ese token en el encabezado `Authorization: Bearer <token>`.

Los usuarios existentes con contraseñas en texto simple se migran a un hash seguro al iniciar sesión correctamente. Las contraseñas ya almacenadas como hash se verifican y no se devuelven en ninguna respuesta.

Las solicitudes protegidas devuelven `401 Unauthorized` con un detalle identificable cuando no se envía token, el token no es válido o ya expiró. Para obtener acceso nuevamente, inicia sesión y usa el token nuevo.

## Operaciones disponibles

Las consultas son solicitudes `GET` y requieren autenticación. En Swagger, inicia sesión, autoriza con el token, selecciona una operación, pulsa **Try it out**, completa los parámetros si los hay y luego **Execute**.

| Operación | Ruta | Resultado |
|---|---|---|
| Listar operaciones de crédito | `GET /api/Creditos` | Lista de operaciones de crédito. |
| Listar créditos de un titular | `GET /api/Creditos/titular/{idTitular}` | Operaciones vinculadas al titular indicado. |
| Listar titulares | `GET /api/Titulares` | Lista de titulares. |
| Consultar titular por ID | `GET /api/Titulares/{id}` | Titular correspondiente al ID. |
| Listar roles | `GET /api/Roles` | Lista de roles. |
| Consultar rol por ID | `GET /api/Roles/{id}` | Rol correspondiente al ID. |
| Listar usuarios | `GET /api/Usuarios` | Lista de usuarios sin el campo de contraseña. |
| Consultar usuario por ID | `GET /api/Usuarios/{id}` | Usuario correspondiente al ID, sin el campo de contraseña. |
| Listar pagos | `GET /api/Pagos` | Lista de pagos. |
| Consultar pago por ID | `GET /api/Pagos/{id}` | Pago correspondiente al ID. |

Reemplaza `{id}` o `{idTitular}` por un número entero. Por ejemplo:

```text
GET http://localhost:5004/api/Titulares/1
GET http://localhost:5004/api/Creditos/titular/1
```

## Cómo interpretar las respuestas

- **200 OK**: solicitud exitosa. Una consulta por ID devuelve un objeto JSON; una consulta de lista devuelve un arreglo JSON.
- **200 OK con `[]`**: una consulta de lista se ejecutó correctamente, pero no hay registros que devolver.
- **404 Not Found**: no se encontró el registro solicitado por ID. La respuesta incluye un campo `mensaje`. La búsqueda de créditos por titular también devuelve 404 si no hay operaciones para ese titular.
- **500 Internal Server Error**: ocurrió un error en el servidor. Si sucede al consultar datos, verifica que SQL Server esté ejecutándose, que la instancia y la base de datos de la cadena de conexión sean correctas, y que el usuario de Windows tenga acceso.

Las respuestas de usuarios omiten intencionalmente la contraseña. Las demás propiedades devueltas corresponden a los datos del modelo.

## Cómo realizar pruebas

### Desde Swagger

1. Inicia el proyecto y abre Swagger.
2. Prueba una consulta de lista, por ejemplo `GET /api/Roles`.
3. Prueba una consulta por ID con un ID existente.
4. Repite con un ID que no exista y comprueba la respuesta `404`.
5. Prueba `GET /api/Creditos/titular/{idTitular}` con un titular que tenga créditos y con otro que no tenga operaciones.
6. En las respuestas de usuarios, confirma que no aparezca una propiedad de contraseña.

Las consultas necesitan una conexión válida a SQL Server y datos disponibles en la base de datos.

### Desde PowerShell

Con la aplicación ejecutándose en el perfil HTTP, estas solicitudes permiten probar los endpoints:

```powershell
$login = Invoke-RestMethod -Uri "http://localhost:5004/api/Auth/login" -Method Post `
  -ContentType "application/json" -Body '{"correo":"usuario@example.com","contrasena":"tu-contrasena"}'
$headers = @{ Authorization = "Bearer $($login.token)" }
Invoke-RestMethod -Uri "http://localhost:5004/api/Titulares" -Headers $headers
Invoke-RestMethod -Uri "http://localhost:5004/api/Titulares/1" -Headers $headers
Invoke-RestMethod -Uri "http://localhost:5004/api/Creditos/titular/1" -Headers $headers
Invoke-RestMethod -Uri "http://localhost:5004/api/Roles" -Headers $headers
Invoke-RestMethod -Uri "http://localhost:5004/api/Usuarios" -Headers $headers
Invoke-RestMethod -Uri "http://localhost:5004/api/Pagos/1" -Headers $headers
```

Sustituye los IDs de ejemplo por valores que existan en tu base de datos. Para revisar el estado HTTP y el cuerpo de una respuesta de error, puedes usar Swagger o una herramienta HTTP como la extensión REST Client de VS Code.
