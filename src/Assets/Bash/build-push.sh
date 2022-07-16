#!/bin/bash

if [ "$1" == "" ]; then
    VERSION="latest"
else
    VERSION=$1
fi

docker push reg.xyz.com/project/image-name:$VERSION