#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/Logging/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/logging-web/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:logging-web .
cd /build/
rm -rf /build/temp/
