cd C:\Projects\MicroserviceRabbitMQ\Logging\src\Caller
dotnet publish -c Release -o c:\temp\msrmq\logging-caller
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a logging-caller.7z c:\temp\msrmq\logging-caller
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-caller\app
copy c:\temp\msrmq\logging-caller.7z
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-caller
rem docker build -t fpommerening/msrmq:logging-caller .


cd C:\Projects\MicroserviceRabbitMQ\Logging\src\ConsoleListener
dotnet publish -c Release -o c:\temp\msrmq\logging-console
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a logging-console.7z c:\temp\msrmq\logging-console
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-console\app
copy c:\temp\msrmq\logging-console.7z
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-console
rem docker build -t fpommerening/msrmq:logging-console .


cd C:\Projects\MicroserviceRabbitMQ\Logging\src\WebLogger
dotnet publish -c Release -o c:\temp\msrmq\logging-web
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a logging-web.7z c:\temp\msrmq\logging-web
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-web\app
copy c:\temp\msrmq\logging-web.7z
cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\logging-web
rem docker build -t fpommerening/msrmq:logging-web .


cd C:\Projects\MicroserviceRabbitMQ\Logging\dockerfiles\weblogger