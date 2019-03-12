<b>Instalação Angular</b>

Requisitos:
NodeJs (https://nodejs.org/en/) versão recomendada - 10.15.3
Visual Code (https://code.visualstudio.com/ )

Visual code -> Open Folder -> abrir a pasta FRONT do projeto

Depois de aberto
Terminal -> New Terminal -> npm install //Criara uma pasta de node_modules
Em seguida: npm install -g @angular/cli@7.1.0 (se não tiver instalado)
Para rodar o projeto: ng serve --open
Obs: caso dê erro no comando ng serve, tente 'npm run ng serve'


<b>Instalação API</b>

1 - Abrir solution
2 - Selecionar projeto API -> Set as StartUp Project 
3 - Abrir Package Manager Console -> Selecionar 'Infra' como default project
4 - Executar o comando: update-database -v
