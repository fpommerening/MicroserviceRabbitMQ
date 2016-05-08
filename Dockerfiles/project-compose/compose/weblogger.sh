mkdir weblogger
cp /projects/MicroserviceRabbitMQ/Dockerfiles/weblogger/docker-compose.yml /compose/weblogger/
cd weblogger
/usr/local/bin/docker-compose $*
cd /compose/
rm -rf weblogger
