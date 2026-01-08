docker run --name redis -p 6379:6379 -d redis

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123456.Test" -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server:2022-latest

docker run --name mysql-server -e MYSQL_ROOT_PASSWORD=123.Pass -p 3306:3306 -v mysql_data:/var/lib/mysql -d mysql:latest