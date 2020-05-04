FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY . ./
RUN dotnet build

# FROM build AS test
# WORKDIR /app/Urly.Tests
# RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/Taskly.Workflow.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app/Taskly.Workflow.WebApi/out .
ENTRYPOINT ["dotnet", "Taskly.Workflow.WebApi.dll"]
