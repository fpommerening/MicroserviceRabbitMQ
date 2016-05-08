#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/ProcessChain/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/process-webbroker/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:process-webbroker .
cd /build/
rm -rf /build/temp/
