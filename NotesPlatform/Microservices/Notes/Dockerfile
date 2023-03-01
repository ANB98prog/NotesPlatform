FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NotesApi/NotesApi.csproj", "NotesApi/"]
COPY ["NotesApplication/NotesApplication.csproj", "NotesApplication/"]
COPY ["NotesDomain/NotesDomain.csproj", "NotesDomain/"]
COPY ["NotesPersistence/NotesPersistence.csproj", "NotesPersistence/"]
RUN dotnet restore "NotesApi/NotesApi.csproj"
COPY . .
WORKDIR "/src/NotesApi"
RUN dotnet build "NotesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApi.dll"]