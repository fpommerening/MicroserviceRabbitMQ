FROM debian:jessie
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-05-08

RUN set -x \
	&& mkdir /rabbitssl && cd /rabbitssl \
	&& apt-get update && apt-get install -y --no-install-recommends openssl && rm -rf /var/lib/apt/lists/* \
	&& apt-get purge -y --auto-remove

COPY openssl.cnf /usr/local/bin/
COPY *.sh /usr/local/bin/
