FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR nttdata

EXPOSE 80
EXPOSE 5024

COPY ./Nttdata.Steven.Jurado.Api/*.csproj ./
RUN dotnet restore "Nttdata.Steven.Jurado.Api.csproj"

COPY ./Nttdata.Steven.Jurado.Application/*.csproj ./
RUN dotnet restore "Nttdata.Steven.Jurado.Application.csproj"

COPY ./Nttdata.Steven.Jurado.Domain/*.csproj ./
RUN dotnet restore "Nttdata.Steven.Jurado.Domain.csproj"

COPY ./Nttdata.Steven.Jurado.Repository/*.csproj ./
RUN dotnet restore "Nttdata.Steven.Jurado.Repository.csproj"

COPY ./Nttdata.Steven.Jurado.Repository.Sql/*.csproj ./
RUN dotnet restore "Nttdata.Steven.Jurado.Repository.Sql.csproj"



COPY ./Nttdata.Steven.Jurado.Api ./
COPY ./Nttdata.Steven.Jurado.Application ./
COPY ./Nttdata.Steven.Jurado.Domain ./
COPY ./Nttdata.Steven.Jurado.Repository ./
COPY ./Nttdata.Steven.Jurado.Repository.Sql ./
RUN dotnet publish "Nttdata.Steven.Jurado.Api.csproj" -c Release -o out 


FROM mcr.microsoft.com/dotnet/sdk:5.0 
WORKDIR /nttdata
COPY --from=build	/nttdata/out .
ENTRYPOINT ["dotnet", "Nttdata.Steven.Jurado.Api.dll"]