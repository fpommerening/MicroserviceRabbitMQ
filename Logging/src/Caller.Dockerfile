FROM microsoft/dotnet:2.0-sdk-jessie AS builder

WORKDIR /app
COPY Caller /app/
RUN dotnet restore Caller.csproj
RUN dotnet publish --configuration Release --output ./out


FROM microsoft/dotnet:2.0-runtime
LABEL maintainer "frank@pommerening-online.de"
ENV REFRESHED_AT 2018-04-08

WORKDIR /app/
COPY --from=builder /app/out/* ./
ENTRYPOINT ["dotnet", "FP.MsRmq.Logging.Caller.dll"]