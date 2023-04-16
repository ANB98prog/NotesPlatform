# Notes platform

There are backend and frontend parts:
1. NotesPlatform (backend - C#)
2. PlatformUI (frontend - React)

## How to launch
1. Build the project by running command `docker compose build`
2. Run containers by running command `docker compose up -d`

If you want run with separate database you should change in docker-compose.yml file ASPNETCORE_ENVIRONMENT variable from Development to Staging and uncomment *postgress* service and *depends_on* in notes service 
