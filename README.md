# FunctionXmlProcess
# Downloads necessários:
+ https://azure.microsoft.com/en-us/products/storage/storage-explorer/
+ Instale o Azurite via NPM com o seguinte comando: npm install -g azurite
+ Agora para startar o Serviço Azurite e poder Emular no Storage Explorer rode o seguinte comando: azurite --silent --location c:\azurite --debug c:\azurite\debug.log
## Descrição:
<p> Projeto serveless com Azure-Functions, que basicamente recebe um XML, trigga uma função que vai processar esse XML, 
  pegar os dados e criar um novo Doc com base na classe DocFile que está no projeto e jogar para uma Queue.</p>
<p> E a partir disso, uma outra função é ativada que vai processar esse documento e com base numa DocEntity,
  vai pegar os dados do XML e dar a ele keys, partitions e jogar esse arquivo para uma Tabela (base de dados) </p>

