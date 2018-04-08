#!/bin/sh
mkdir /rabbitssl/server
cd /rabbitssl/server
openssl genrsa -out key.pem 4096
openssl req -new -key key.pem -out req.pem -outform PEM -subj /CN=$1/O=server/ -nodes
cd /rabbitssl/ca
openssl ca -config openssl.cnf -in /rabbitssl/server/req.pem -out /rabbitssl/server/cert.pem -notext -batch -extensions server_ca_extensions
cd /rabbitssl/server
openssl pkcs12 -export -out keycert.p12 -in cert.pem -inkey key.pem -passout pass:$2
