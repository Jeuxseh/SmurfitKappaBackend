Antes de compilar el proyecto:
- Recordar modificar la cadena de conexión en el appsettings.json para conectar (en mi caso antes era DESKTOP-UAOJR3S, he dejado "Nombre-de-equipo").
- La tabla User para almacenar la información de la prueba debería crearse sola mediante "EnsureCreated", así que no habría que hacer nada más.
- El proyecto incluye tests para sus 3 capas (controlador, servicio y repositorio).
