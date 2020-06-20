FROM mcr.microsoft.com/dotnet/core/sdk:5.0-alpine AS base

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

WORKDIR /app
COPY src/MyWeb/MyWeb.fsproj src/MyWeb/
RUN dotnet restore src/MyWeb

COPY src/MyWeb src/MyWeb
RUN dotnet publish src/MyWeb \
    -r linux-musl-x64 \
    -c $BUILDCONFIG \
    -o out \
    /p:Version=$VERSION \
    -p:PublishTrimmed=true

# runtime
FROM mcr.microsoft.com/dotnet/core/runtime-deps:5.0-alpine
WORKDIR /app
COPY --from=base /app/out ./

EXPOSE 80
ENTRYPOINT ["./MyWeb"]