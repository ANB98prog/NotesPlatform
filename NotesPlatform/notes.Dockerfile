FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Notes/NotesApi/NotesApi.csproj", "Microservices/Notes/NotesApi/"]
COPY ["Microservices/Notes/NotesApplication/NotesApplication.csproj", "Microservices/Notes/NotesApplication/"]
COPY ["Microservices/Notes/NotesDomain/NotesDomain.csproj", "Microservices/Notes/NotesDomain/"]
COPY ["Microservices/Notes/NotesPersistence/NotesPersistence.csproj", "Microservices/Notes/NotesPersistence/"]
COPY ["Exceptions/ApiExceptions.csproj", "Exceptions/"]
RUN dotnet restore "Microservices/Notes/NotesApi/NotesApi.csproj"
COPY . .
WORKDIR "/src/Microservices/Notes/NotesApi"
RUN dotnet build "NotesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApi.dll"]