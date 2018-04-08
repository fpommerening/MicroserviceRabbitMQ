#!/bin/sh
cp /usr/local/bin/openssl.cnf /rabbitssl/ca
cd /rabbitssl/ca/

mkdir certs/
mkdir private
chmod 700 private
echo 01 > serial
touch index.txt

openssl req -x509 -config openssl.cnf -newkey rsa:4096 -days 365 -out cacert.pem -outform PEM -subj /CN=$1/ -nodes
openssl x509 -in cacert.pem -out cacert.cer -outform DER
