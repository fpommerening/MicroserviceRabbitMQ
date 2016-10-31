FROM dduportal/docker-compose
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-25

RUN mkdir /compose
COPY ./docker-compose.yml /compose/docker-compose.yml
WORKDIR /compose/
ENTRYPOINT ["/bin/bash"]

