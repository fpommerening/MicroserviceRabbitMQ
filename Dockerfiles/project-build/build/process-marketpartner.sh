#!/bin/sh
mkdir temp
cp -r /projects/MicroserviceRabbitMQ/MarketPartner/Web/bin/Release/ /build/temp/app/
cp /projects/MicroserviceRabbitMQ/Dockerfiles/process-marketpartner/Dockerfile /build/temp/
cd /build/temp/
docker build -t fpommerening/msrmq:process-marketpartner .
cd /build/
rm -rf /build/temp/
