
### Docker build Restaurante Service

```` bash 
docker build -t restauranteservice:1.0 .
````

### Docker build Item Service

```` bash 
docker build -t itemservice:1.0 .
````

### Docker Run MySql 5.6 

````bash 
docker run --name=mysql -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge  mysql:5.6
````

### Docker create network - criar rede

````bash 
docker network create --driver bridge restaurante-bridge
````

### Docker run MySql - adcionar a rede

````bash 
docker run --name=mysql -e MYSQL_ROOT_PASSWORD=root -d --network restaurante-bridge  mysql:5.6

````

### Docker Run restaurante-service - a adcionar rede 
````bash 
docker run --name restaurante-service -p 8081:80 --network restaurante-bridge restauranteservice:1.0
````

### Docker Run item-service - a adcionar rede 
````bash 
docker run --name item-service -d -p 8080:80 --network restaurante-bridge itemservice:1.0
````