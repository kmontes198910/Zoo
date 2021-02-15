# Proyecto de prueba en DotNet Core 5.0

Debe tener Docker y docker-compose instalados para ejecutar el proyecto
en un contenedor.

Una vez instalados los requisitos, ejecute el siguiente comando
desde la carpeta raíz de la solución:

```
docker-compose up --build -d
```

El comando anterior creará una imagen y un contenedor con el
aplicativo. Puede acceder a la interfaz swagger en la siguiente
dirección https://localhost:5001/swagger/index.html

Desde la interfaz de swagger, genere el token para realizar solicitudes
al endpoint con las siguientes credenciales:

admin: Pa$$w0rd

docker-compose ejecutará un contenedor PostgreSQL para almacenamiento
de los datos.
