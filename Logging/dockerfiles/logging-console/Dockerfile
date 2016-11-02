FROM fpommerening/msrmq:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-11-02
ENV Console_VERSION 1.0.2

# COPY /app /home/

RUN set -x \
	&& wget -O /home/logging-console.7z "https://github.com/fpommerening/MicroserviceRabbitMQ/releases/download/$Console_VERSION/logging-console.7z" \
    && p7zip -d /home/logging-console.7z \
    && mv /logging-console/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "Console.dll"]