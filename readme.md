# Pdi API

### Como rodar o projeto

Execute os comandos:

```
    cd pdiapi
    docker build . -t pdiapi:3.1
    docker run -d -p 8080:80 --mount source=pdiapi-database,target=/var/www/database --name pdiapi pdiapi:3.1
```

Utilize as flags --memory=\*valor\* e --cpus=\*valor\* no comando run para definir limites de memória e CPU para o container

### Verificar se o projeto está executando:

```
    docker ps
```
