# for sql server, which we better not use :puke:

#docker container create -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=password" -p 1433:1433 --name sql1 mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04    
#docker container start sql1