
## Rodar Serviços

Docker build Restaurante Service

```` powershell 
docker build -t restauranteservice:1.0 .
````

Docker build Item Service

```` powershell
docker build -t itemservice:1.0 .
````

Docker Run MySql 5.6 

````powershell
docker run --name=mysql -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge  mysql:5.6
````

Docker create network - criar rede

````powershell
docker network create --driver bridge restaurante-bridge
````

Docker run MySql - adcionar a rede

````powershell
docker run --name=mysql -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge  mysql:5.6

````

Docker Run restaurante-service - a adcionar rede 
````powershell
docker run --name restaurante-service -p 8081:80 --network restaurante-bridge restauranteservice:1.0
````

Docker Run item-service - a adcionar rede 
````powershell 
docker run --name item-service -d -p 8080:80 --network restaurante-bridge itemservice:1.0
````
Docker Run rabbitmq-service - a adcionar rede 
````powershell 
docker run -d --hostname rabbitmq-service --name rabbitmq-service --network restaurante-bridge rabbitmq:3-management
````

## Getting Started

````powershell
docker-compose build
docker-compose up
````