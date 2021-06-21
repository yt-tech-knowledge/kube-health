FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# copy the csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# build the application
COPY . ./
RUN dotnet publish -c Release -o out

# build the image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Kubehealth.dll"]