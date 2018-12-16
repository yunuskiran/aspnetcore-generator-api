FROM microsoft/dotnet:sdk
WORKDIR /integration-test

COPY integration-test.csproj .
RUN dotnet restore
 
COPY . .
ENTRYPOINT ["dotnet","test"]