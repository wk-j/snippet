export DOCKER_BUILDKIT=1
export COMPOSE_DOCKER_CLI_BUILD=1
export VERSION=latest

if [ "$1" == "" ]; then
    VERSION="latest"
else
    VERSION=$1
fi

docker build -f docker/Gateway.Dockerfile -t reg.bcecm.com/pttor/gateway-service:$VERSION .