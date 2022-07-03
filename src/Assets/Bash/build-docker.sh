export DOCKER_BUILDKIT=1
export COMPOSE_DOCKER_CLI_BUILD=1
export VERSION=latest

if [ "$1" == "" ]; then
    VERSION="latest"
else
    VERSION=$1
fi

docker build -f docker/Dockerfile -t reg.xyz.com/project/image-name:$VERSION .