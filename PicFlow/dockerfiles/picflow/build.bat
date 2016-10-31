cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\Authorization
dotnet publish -c Release -o c:\temp\msrmq\picflow-authorization
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-authorization.7z c:\temp\msrmq\picflow-authorization
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-authorization\app
copy c:\temp\msrmq\picflow-authorization.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-authorization
rem docker build -t fpommerening/devopenspace2016:picflow-authorization .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\ImagePersistor
dotnet publish -c Release -o c:\temp\msrmq\picflow-persistor
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-persistor.7z c:\temp\msrmq\picflow-persistor
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-persistor\app
copy c:\temp\msrmq\picflow-persistor.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-persistor
rem docker build -t fpommerening/devopenspace2016:picflow-persistor .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\ImageProcessor
dotnet publish -c Release -o c:\temp\msrmq\picflow-processor
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-processor.7z c:\temp\msrmq\picflow-processor
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-processor\app
copy c:\temp\msrmq\picflow-processor.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-processor
rem docker build -t fpommerening/devopenspace2016:picflow-processor .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\Uploader
dotnet publish -c Release -o c:\temp\msrmq\picflow-uploader
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-uploader.7z c:\temp\msrmq\picflow-uploader
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-uploader\app
copy c:\temp\msrmq\picflow-uploader.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-uploader
rem docker build -t fpommerening/devopenspace2016:picflow-uploader .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\WebApp
dotnet publish -c Release -o c:\temp\msrmq\picflow-webapp
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-webapp.7z c:\temp\msrmq\picflow-webapp
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-webapp\app
copy c:\temp\msrmq\picflow-webapp.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-webapp
rem docker build -t fpommerening/devopenspace2016:picflow-webapp .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\src\ExternalApp
dotnet publish -c Release -o c:\temp\msrmq\picflow-extapp
cd c:\temp\msrmq
"c:\Program Files\7-Zip"\7z a picflow-extapp.7z c:\temp\msrmq\picflow-extapp
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-extapp\app
copy c:\temp\msrmq\picflow-extapp.7z
cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow-extapp
rem docker build -t fpommerening/devopenspace2016:picflow-extapp .

cd C:\Projects\MicroserviceRabbitMQ\PicFlow\dockerfiles\picflow