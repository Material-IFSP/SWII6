# TP03

# INSTRUÇÕES GERAIS PARA SUBIR O PROJETO

# Instalar pacotes do entity FrameWork

Caso os pacotes não estejam instalados na sua maquina, instale a ultima versão para o .NET 5.0

dotnet add package Microsoft.EntityFrameworkCore --version 5.0.12

dotnet add package Microsoft.EntityFrameworkCore.Relational --version 5.0.12

dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.12

# Usando e Configurando outros bancos

Se precisar Usar outro banco, como sqlLite ou MySql, apague a pasta MIGRATIONS dentro do project Tp03.WebApplication;

Altere a configuration no startup do projeto no codigo abaixo:

services.AddDbContext<Tp03Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),  action => action.MigrationsAssembly("Tp03.WebApplication")));

Onde está UseSqlServer, altere para o banco da sua escolha, se não estiver disponivel, baixe o pacote para o banco correspondente.

Após rode o comando abaixo:

# Criar migration inicial

dotnet ef migrations add InitialCreate

# Subir migration para o banco

dotnet ef database update



Se tudo der certo, é só rodar o projeto :D




