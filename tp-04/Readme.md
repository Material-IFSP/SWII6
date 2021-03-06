# COMO RODAR O PROJETO

# PREPARANDO O AMBIENTE

- Instale o docker.
- Caso esteja usando o windows, ative o WLS no power shell com os comandos abaixo:
 
<br> => dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart
<br> => dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart
<br> => baixar o kernel do linux : https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi
<br> => OBSERVAÇÃO: Consulte a documentação oficial da Microsoft para mais detalhes:  https://docs.microsoft.com/pt-br/windows/wsl/install-manual#step-4---download-the-linux-kernel-update-package


# PRIMEIROS PASSOS

 - Com o docker instalado e configurado, reinicie a maquina para se certificar que toda a instalação foi sucedida.
 - Abra o Diretorio do projeto, e na pasta raiz onde está o arquivo Docker "docker-compose.yaml" rode o comando abaixo:
<br> => docker-compose up -d
- O docker irá montar todo o projeto e o mesmo pode ser encontrado na aba CONTAINERS/APPS intitulado "TP-04";
- verifique todas as portas utilizadas nas aplicações, iremos utilizar-las mais tarde.
- Certifique-se que todo o projeto está rodando corretamente como no abaixo:

  <div>
  <img src="https://github.com/Material-IFSP/SWII6/blob/main/tp-04/print01.png?raw=true">
  </div>


# CONFIGURANDO NODE E YARN
- Dentro do projeto  "Tp04.DesktopApp" abra o terminal;
- Caso não possua o node instalado, instale-o.
- Com o terminal aberto, instale o yarn:
<br> =>  npm install --global yarn
-  Após a instalação instale as dependencias do yarn:
<br>  => yarn install

# APOTANDO A APLICAÇÃO PARA A SUA WEBAPI
- Lembra-se que pedi para guardar as portas utilizadas na aplicação? Agora precisaremos da porta da sua api para setarmos na aplicação Desktop;
- Com a porta e a rota em mãos, sete a mesma no seguinte Diretorio "Tp04.DesktopApp/src/config/api.ts", o arquivo deve ficar mais ou menos assim:

   
  <div>
  <img src="https://github.com/Material-IFSP/SWII6/blob/main/tp-04/print02.png?raw=true">
  </div>

# GERANDO O BUILD DA APLICAÇÃO DESKTOP
- Agora basta gerar o build da sua aplicação, para isto rode o comando abaixo
<br>   => yarn package
-  O build, juntamente com o executavel para o seu os está dentro do Diretorio "packages/TEU_OS";

# BASTA RODAR O EXECUTAVEL E GG :D



