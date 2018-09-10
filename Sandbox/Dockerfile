# Build Stage
FROM 	microsoft/dotnet:2.1-sdk as build-env
WORKDIR	/api

COPY	Sandbox.csproj .
RUN		dotnet restore

COPY	. .
RUN		dotnet publish -o /publish

# Runtime Image Stage
FROM 	microsoft/dotnet:2.1-aspnetcore-runtime as runtime-env
WORKDIR	/publish
COPY	--from=build-env /publish .
ENTRYPOINT	["dotnet", "Sandbox.dll"]