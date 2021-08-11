#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ToDoApp.Api/ToDoApp.Api.csproj", "src/ToDoApp.Api/"]
COPY ["src/ToDoApp.ApplicationService/ToDoApp.ApplicationService.csproj", "src/ToDoApp.ApplicationService/"]
COPY ["ToDoApp.Repository/ToDoApp.Repository.csproj", "ToDoApp.Repository/"]
COPY ["src/ToDoApp.Domain/ToDoApp.Domain.csproj", "src/ToDoApp.Domain/"]
COPY ["src/ToDoApp.ApiContract/ToDoApp.ApiContract.csproj", "src/ToDoApp.ApiContract/"]
RUN dotnet restore "src/ToDoApp.Api/ToDoApp.Api.csproj"
COPY . .
WORKDIR "/src/src/ToDoApp.Api"
RUN dotnet build "ToDoApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Api.dll"]