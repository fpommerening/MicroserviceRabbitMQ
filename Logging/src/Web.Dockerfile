FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /app/WebLogger
COPY Contracts /app/Contracts
COPY WebLogger /app/WebLogger

RUN dotnet restore WebLogger.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/aspnetcore:2.0-jessie
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-04-08

WORKDIR /app/
COPY --from=builder /app/WebLogger/out/* ./

ENV ASPNETCORE_URLS http://0.0.0.0:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "FP.MsRmq.Logging.WebLogger.dll"]