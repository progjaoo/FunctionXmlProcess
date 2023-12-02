# FunctionXmlProcess
## Descrição:
<p> Projeto serveless com Azure-Functions, que basicamente recebe um XML, trigga uma função que vai processar esse XML, 
  pegar os dados e criar um novo Doc com base na classe DocFile que está no projeto e jogar para uma Queue.</p>
<p> E a partir disso, uma outra função é ativada que vai processar esse documento e com base numa DocEntity,
  vai pegar os dados do XML e dar a ele keys, partitions e jogar esse arquivo para uma Tabela (base de dados) </p>
##Downloads: Faça o Download do Azure Storage Explorer da Microsoft para emular a Nuvem, para não precisar ficar postando projeto toda hora:
<p> Agora instale o Azurite para poder Emular: npm install -g azurite</p>
<p> Em seguide rode o comando do Azurite para poder startar o serviço: azurite --silent --location c:\azurite --debug c:\azurite\debug.log</p>
