#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/Logging/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/logging-console/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:logging-console .
cd /build/
rm -rf /build/temp/
