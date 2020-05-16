#!/bin/bash

SdkVersion="3.1.202"
./dotnet-install.sh -Version $SdkVersion
export PATH="$PATH:$HOME/.dotnet"
