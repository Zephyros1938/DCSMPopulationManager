#!/bin/sh
clear

buildLog=`dotnet build`

echo -e "${buildLog//. /.\n}" > build_log.txt

cat build_log.txt

dotnet run /bin/Debug/net8.0/DCSMPopulationManager.csproj