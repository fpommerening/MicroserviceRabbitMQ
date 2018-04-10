#!/bin/sh
mkdir /rabbitssl/client
cd /rabbitssl/client
openssl genrsa -out key.pem 4096
openssl req -new -key key.pem -out req.pem -outform PEM -subj /CN=$1/O=client/ -nodes
cd /rabbitssl/ca
openssl ca -config openssl.cnf -in /rabbitssl/client/req.pem -out /rabbitssl/client/cert.pem -notext -batch -extensions client_ca_extensions
cd /rabbitssl/client
openssl pkcs12 -export -out keycert.p12 -in cert.pem -inkey key.pem -passout pass:$2