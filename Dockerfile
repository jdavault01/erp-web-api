FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Pki.eBusiness.ErpApi.Web/Pki.eBusiness.ErpApi.Web.csproj", "Pki.eBusiness.ErpApi.Web/"]
COPY ["Pki.eBusiness.ErpApi.Entities/Pki.eBusiness.ErpApi.Entities.csproj", "Pki.eBusiness.ErpApi.Entities/"]
COPY ["Pki.eBusiness.ErpApi.Business/Pki.eBusiness.ErpApi.Business.csproj", "Pki.eBusiness.ErpApi.Business/"]
COPY ["Pki.eBusiness.ErpApi.Contract/Pki.eBusiness.ErpApi.Contract.csproj", "Pki.eBusiness.ErpApi.Contract/"]
COPY ["Pki.eBusiness.ErpApi.Logger/Pki.eBusiness.ErpApi.Logger.csproj", "Pki.eBusiness.ErpApi.Logger/"]
COPY ["Pki.eBusiness.ErpApi.DataAccess/Pki.eBusiness.ErpApi.DataAccess.csproj", "Pki.eBusiness.ErpApi.DataAccess/"]
RUN dotnet restore "Pki.eBusiness.ErpApi.Web/Pki.eBusiness.ErpApi.Web.csproj"
COPY . .
WORKDIR "/src/Pki.eBusiness.ErpApi.Web"
RUN dotnet build "Pki.eBusiness.ErpApi.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pki.eBusiness.ErpApi.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pki.eBusiness.ErpApi.Web.dll"]