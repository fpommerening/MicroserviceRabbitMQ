FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /app/Console
COPY Console /app/Console
COPY Contracts /app/Contracts

RUN dotnet restore Console.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.0-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-04-08

WORKDIR /app/
COPY --from=builder /app/Console/out/* ./
ENTRYPOINT ["dotnet", "FP.MsRmq.Logging.Console.dll"]