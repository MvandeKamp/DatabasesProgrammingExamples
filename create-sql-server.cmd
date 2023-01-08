echo "Creating Database Container"
docker create --name dbe-sql -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=myADMPassword1!" -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
echo "Starting Database Container"
docker start dbe-sql