FROM fpommerening/msrmq:core-base
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2017-05-05
ENV Picflow_VERSION 2.0.0

RUN set -x \
    && curl -o /home/webapp.tar.gz "https://github.com/fpommerening/MicroserviceRabbitMQ/releases/download/$Picflow_VERSION/webapp.tar.gz" 

RUN set -x \
    && mkdir /app/ \
    && tar -xzf /home/webapp.tar.gz -C /app/

WORKDIR /app/
ENTRYPOINT ["dotnet", "WebApp.dll"]