#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/Samples/Logging/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/logging-caller/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:logging-caller .
cd /build/
rm -rf /build/temp/
