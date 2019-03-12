<b>Instalação Angular</b> <br><br>

Requisitos: <br>
NodeJs (https://nodejs.org/en/) versão recomendada - 10.15.3 <br>
Visual Code (https://code.visualstudio.com/ )

Visual code -> Open Folder -> abrir a pasta FRONT do projeto <br><br>

Depois de aberto <br>
Terminal -> New Terminal -> npm install //Criara uma pasta de node_modules <br>
Em seguida: npm install -g @angular/cli@7.1.0 (se não tiver instalado) <br>
Para rodar o projeto: ng serve --open <br>
Obs: caso dê erro no comando ng serve, tente 'npm run ng serve' <br>


<b>Instalação API</b><br><br>

1 - Abrir solution / Buildar projeto <br>
2 - Selecionar projeto API -> Set as StartUp Project <br>
3 - Abrir Package Manager Console -> Selecionar 'Infra' como default project <br>
4 - Executar o comando: update-database -v <br>
