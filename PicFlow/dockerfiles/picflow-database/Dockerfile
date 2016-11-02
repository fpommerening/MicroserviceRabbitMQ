FROM postgres
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-31
ENV POSTGRES_USER msrmq
ENV POSTGRES_PASSWORD leipzig
ADD init.sql /docker-entrypoint-initdb.d/
EXPOSE 5432