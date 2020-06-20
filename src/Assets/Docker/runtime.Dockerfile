FROM mcr.microsoft.com/dotnet/core/sdk:5.0 as build
WORKDIR /app

COPY src/MyWeb/MyWeb.fsproj src/MyWeb/
RUN dotnet restore src/MyWeb

COPY src/MyWeb src/MyWeb
RUN dotnet publish src/MyWeb \
    -c Release \
    -o /app \
    -r linux-x64

# runtime
FROM mcr.microsoft.com/dotnet/core/runtime:5.0 AS runtime
WORKDIR /app
COPY --from=build /app .
CMD dotnet MyWeb.dll
EXPOSE 80