# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, foi preciso usar os conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Solução
O programa contém duas classes chamadas "Estacionamento" e "FichaEstacionamento".

A classe "FichaEstacionamento" é composta por três variáveis, sendo:

**placa**: Tipo string. É a placa do veículo que está sendo estacionado.

**cpf**: Tipo string. É o CPF do responsável que está cadastrando o veículo.

**horaEntrada**: Tipo datetime. É a data em que o veículo está sendo estacionado.

A classe "Estacionamento" é composta por quatro variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**capacidadeEstacionamento** : Tipo inteiro. É a quatidade de vagas totais do estacionamento (quantos veículos podem ser estacionados).

**vagas**: É um Array do tipo _FichaEstacionamento_, representando uma coleção de veículos estacionados.

Duas constantes:

**PadraoPlaca**: Tipo string. É o padrão em Regex que todas as placas precisam seguir para serem cadastradas.

**PadraoCpf**: Tipo string. É o padrão em Regex que todos os cpfs precisam seguir para serem cadastrados.

Três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa e cpf digitados pelo usuário de acordo com o padrão imposto, pegar a data do momento do cadastro, criar uma instância **FichaEstacionamento** com essas informações e guardar na variável **vagas**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado e se o cpf de quem o está solicitando corresponde ao responsável pelo veículo, e caso positivo, irá calcular o tempo total que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, foi feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar