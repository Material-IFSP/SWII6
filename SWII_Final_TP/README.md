# Trabalho Prático Final
## Autores: Renato Santos e Fernando Avelino
Trabalho efetuado para a disciplina de Sistemas Web 2.

### Contém
- [x] Banco que dados capaz de armazenar informações de Usuário / Produto
- [x] API contem todos os métodos CRUD para o Usuário e Produto
- [x] A gestão de usuários efetuada através de uma aplicação Desktop
- [x] Operações de produto devem ser executadas através de WebSite

## Como rodar o projeto

Ao clonar o projeto, basta rodar o mesmo, e instalar os pacotes necessários caso não os tenha na máquina.
No Package Manager do Visual Studio rode o comando:
    => Update-Database

Caso esteja usando o vs code rode o comando: 
    => dotnet ef database update

## Caso esteja usando outro banco de dados que não seja o SQL SERVER

As migrations geradas na aplicação são referentes ao SQL SERVER.
Se desejar usar outro banco terá de configurar o mesmo no startup da API.
Após definir as configurações no startup, procure a pasta chamada "MIGRATIONS" no projeto e apague-a.
Após isso rode comando:
 => migrations add InitialCreate

Caso esteja usando o vs code rode o comando: 
    => dotnet ef migrations add InitialCreate

Com todo o processo acima concluído, retorne para o passo-a-passo anterior até rodar o comando para subir as migrations banco.


# Pacotes utilizados

**API**
- Microsoft.AspNetCore.Mvc.NewtonsoftJson (versão 3.0.0)
- Microsoft.EntityFrameworkCore.SqServer
- Microsoft.EntityFrameworkCore.Tools

**Desktop**
- Microsoft.AspNet.WebApi.Client
- Newstonsoft.Json

**Web**
- Newstonsoft.Json
