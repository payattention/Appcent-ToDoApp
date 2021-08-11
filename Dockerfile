#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY *.sln .
COPY src/ToDoApp.Api/*.csproj ./src/ToDoApp.Api/
COPY src/ToDoApp.ApiContract/*.csproj ./src/ToDoApp.ApiContract/
COPY src/ToDoApp.ApplicationService/*.csproj ./src/ToDoApp.ApplicationService/
COPY src/ToDoApp.Domain/*.csproj ./src/ToDoApp.Domain/
COPY src/ToDoApp.Repository/*.csproj ./src/ToDoApp.Repository/
RUN dotnet restore

COPY src/ToDoApp.Api/. ./src/ToDoApp.Api/
COPY src/ToDoApp.ApiContract/. ./src/ToDoApp.ApiContract/
COPY src/ToDoApp.ApplicationService/. ./src/ToDoApp.ApplicationService/
COPY src/ToDoApp.Domain/. ./src/ToDoApp.Domain/
COPY src/ToDoApp.Repository/. ./src/ToDoApp.Repository/

WORKDIR /app/src/ToDoApp.Api
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=build /app/src/ToDoApp.Api/out .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]