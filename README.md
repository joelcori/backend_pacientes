🖥️ Backend – ASP .NET CORE WEB API Configuración para trabajar localmente
✅ Tecnologías

.NET 10

Entity Framework Core

SQL Server 2022

CORS habilitado para comunicar con el frontend


📂 Instalación y ejecución
1️ Clonar el repositorio

git clone https://github.com/joelcori/backend_pacientes.git

2 Ejecutamos


Se ejutara en el puerto https://localhost:8001/
y para visualizar el api vamos a https://localhost:8001/swagger/index.html

* VAMOS USAR SQL SERVER 2022 que esta alojado en la nube
* Esto ya esta configurado en el archivo appsettings.json
* Cabe resaltar que es mala practica dehar las credenciales en el archivo appsettings.json
* Pero para fines practicos y de aprendizaje lo dejaremos asi

* En el archivo Properties/launchSettings.json
* vamos a cambiar el puerto de esta manera lo pondremos "applicationUrl": "https://localhost:8002;http://localhost:5012",

* Con esto ya tendriamos configurado




