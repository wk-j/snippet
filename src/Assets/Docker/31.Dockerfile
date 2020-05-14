FROM mcr.microsoft.com/dotnet/core-nightly/sdk:3.1.101 as build
WORKDIR /app
COPY src/MyWeb src/MyWeb
RUN dotnet build src/MyWeb

FROM build as publish
WORKDIR /app
RUN dotnet publish src/MyWeb -c Release -o /app -r linux-x64

FROM mcr.microsoft.com/dotnet/core-nightly/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet CaatBackend.dll
EXPOSE 80
