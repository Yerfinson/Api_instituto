# Api_instituto
Api_creada acorde a la solicitud de la prueba 

***Prerequisitos:***

En el archivo `appsettings.json` recuerde cambiar el server por el nobre del servidor en donde se restaure la base de datos
que encontrara en este mismo repositorio para un correcto funcionamineto del Api 
```json
{
  "ConnectionStrings": {
    "ColegioContext": "Server=ESKTOP-1Q7JISM\\SQLEXPRESS`; Database=instituto; Integrated Security=True; TrustServerCertificate=True"
  },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

# Endpoint integrados 
## Tabla estudiantes
## GET `/api/Estudents/GetEstudents`

- **Descripción:**
  - Obtiene información sobre estudiantes.
  - Puede obtener todos los estudiantes o filtrar por identificación si se proporciona un parámetro.

- **Parámetros de consulta:**
  - `identificacion` (opcional): Identificación numérica del estudiante para filtrar los resultados.

- **Respuestas:**
  - `200 OK`: La solicitud fue exitosa. Devuelve una lista de estudiantes o un estudiante específico, según el parámetro de identificación.
  - `404 Not Found`: No se encontró un estudiante con la identificación proporcionada.
  - `500 Internal Server Error`: Error interno del servidor.

---

## POST `/api/Estudents/CreateStudent`

- **Descripción:**
  - Crea un nuevo estudiante en la base de datos.

- **Parámetros del cuerpo (JSON):**
  - `documento`: Número de identificación del estudiante.
  - `nombre`: Nombre del estudiante.
  - `apellido`: Apellido del estudiante.

- **Respuestas:**
  - `200 OK`: El estudiante se creó con éxito.
  - `400 Bad Request`: Falta al menos uno de los campos requeridos en el cuerpo de la solicitud.
  - `409 Conflict`: El estudiante con la identificación proporcionada ya existe.
  - `500 Internal Server Error`: Error interno del servidor.

---

## DELETE `/api/Estudents/DeleteEstudentbyidentification`

- **Descripción:**
  - Elimina un estudiante de la base de datos.
  - Como tal no se elimina solo se cambia el estado esto por motivos de seguridad y integridad de una base de datos no se debe eliminar un usuario directamente.

- **Parámetros de consulta:**
  - `identificacion`: Identificación numérica del estudiante que se va a eliminar.

- **Respuestas:**
  - `200 OK`: El estudiante se eliminó con éxito.
  - `404 Not Found`: No se encontró un estudiante con la identificación proporcionada.
  - `500 Internal Server Error`: Error interno del servidor.

---

## PUT `/api/Estudents/UpdateEstudent`

- **Descripción:**
  - Actualiza la información de un estudiante en la base de datos.

- **Parámetros de consulta:**
  - `identificacion`: Identificación numérica del estudiante que se va a actualizar.

- **Parámetros del cuerpo (JSON, al menos uno requerido):**
  - `nombre` (opcional): Nuevo nombre del estudiante.
  - `apellido` (opcional): Nuevo apellido del estudiante.

- **Respuestas:**
  - `200 OK`: La actualización del estudiante fue exitosa.
  - `400 Bad Request`: Se debe proporcionar al menos uno de los campos (`nombre` o `apellido`) para realizar la actualización.
  - `404 Not Found`: No se encontró un estudiante con la identificación proporcionada.
  - `500 Internal Server Error`: Error interno del servidor.
  - 
## Tabla Cursos

## GET `/api/Cursos/GetCourses`

- **Descripción:**
  - Obtiene información sobre cursos.
  - Puede obtener todos los cursos o filtrar por nombre si se proporciona un parámetro.

- **Parámetros de consulta:**
  - `name` (opcional): Nombre del curso para filtrar los resultados.

- **Respuestas:**
  - `200 OK`: La solicitud fue exitosa. Devuelve una lista de cursos o un curso específico, según el parámetro de nombre.
  - `404 Not Found`: No se encontró un curso con el nombre proporcionado.
  - `500 Internal Server Error`: Error interno del servidor.

---

## POST `/api/Cursos/CreateCourse`

- **Descripción:**
  - Crea un nuevo curso en la base de datos.

- **Parámetros del cuerpo (JSON):**
  - `nombre`: Nombre del curso.
  - `descripcion` (opcional): Descripción del curso.

- **Respuestas:**
  - `200 OK`: El curso se creó con éxito.
  - `409 Conflict`: El curso con el nombre proporcionado ya existe.
  - `500 Internal Server Error`: Error interno del servidor.

---

## DELETE `/api/Cursos/DeleteCoursebyname`

- **Descripción:**
  - Elimina un curso de la base de datos.

- **Parámetros de consulta:**
  - `name`: Nombre del curso que se va a eliminar.

- **Respuestas:**
  - `200 OK`: El curso se eliminó con éxito.
  - `404 Not Found`: No se encontró un curso con el nombre proporcionado.
  - `500 Internal Server Error`: Error interno del servidor.


