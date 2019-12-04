FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base

LABEL VERSION="1.11.0"
LABEL MAINTAINER="Andrey Dovbnya"
LABEL NAME = "webapp"

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS publish
WORKDIR /src
COPY . .
RUN dotnet publish "webapp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet"]
CMD [ "webapp.dll" ]