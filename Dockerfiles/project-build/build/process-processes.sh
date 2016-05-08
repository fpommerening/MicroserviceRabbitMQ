#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/ProcessChain/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/process-processes/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:process-processes .
cd /build/
rm -rf /build/temp/
