FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG source=.
WORKDIR /app
COPY $source .
EXPOSE 80

ENTRYPOINT ["dotnet", "ValueApi.dll"]