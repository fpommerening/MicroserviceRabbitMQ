FROM fpommerening/msrmq:core-base
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-10-31
ENV Caller_VERSION 1.0.0

# COPY /app /home/

RUN set -x \
	&& wget -O /home/logging-caller.7z "https://github.com/fpommerening/msrmq/releases/download/$Caller_VERSION/logging-caller.7z" \
    && p7zip -d /home/logging-caller.7z \
    && mv /logging-caller/ /app/ \
	&& apt-get purge -y --auto-remove ca-certificates wget p7zip

WORKDIR /app/
ENTRYPOINT ["dotnet", "Caller.dll"]

