#!/bin/bash
#Add the dotnet path to the path
export PATH="$HOME/.dotnet":$PATH

if [ -d "./artifacts" ]
then
    rm -Rf "./artifacts"; 
fi

dotnet restore

commitHash=$(git rev-parse --short HEAD)
suffix="-ci-local"
buildSuffix="$suffix-$commitHash"

echo "build: Version suffix is $buildSuffix"

dotnet build Notes.sln -c Release --version-suffix "$buildSuffix"  -v q /nologo
