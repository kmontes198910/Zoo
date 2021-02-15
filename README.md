# Sample project in DotNet Core 5.0

You must have Docker and docker-compose installed to run the project
in a container.

Once the requirements are installed, run the following command
from the root folder of the solution:

```
docker-compose up --build -d
```

The above command will create an image and a container with the
app. You can access the swagger interface in the following
address https://localhost:5001/swagger/index.html

From the swagger interface, generate the token to make requests 
to the endpoint with the following credentials:

admin:Pa$$w0rd

docker-compose will run a PostgreSQL container for storage
of the data.

