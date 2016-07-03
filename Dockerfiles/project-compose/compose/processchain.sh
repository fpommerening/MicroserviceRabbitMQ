mkdir processchain
cp -u /projects/MicroserviceRabbitMQ/Dockerfiles/processchain/docker-compose.yml /compose/processchain/
cd processchain
/usr/local/bin/docker-compose $*
cd /compose/
rm -rf processchain
