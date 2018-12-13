FROM microsoft/dotnet:sdk AS build-env

WORKDIR /generator  

COPY api/api.csproj ./api/
RUN dotnet restore api/api.csproj
COPY tests/tests.csproj ./tests/
RUN dotnet restore tests/tests.csproj

COPY . .
RUN dotnet test tests/tests.csproj

RUN dotnet publish api/api.csproj -o /publish

FROM microsoft/dotnet:aspnetcore-runtime
COPY --from=build-env /publish /publish 
WORKDIR /publish
ENTRYPOINT [ "dotnet","api.dll" ]
