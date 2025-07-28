# Trybank

Boas-vindas ao repositório do projeto `Trybank`

O projeto é uma aplicação simples de simulação bancária usando C# e .NET Core/.NET 5+

<details>
<summary><strong>🧑‍💻 O que foi desenvolvido</strong></summary>

Foi desenvovido um sistema de um banco, a aplicação controla contas bancárias bem como realizar as suas operações básicas de checar um saldo, depositar, sacar e transferir dinheiro.
Além disso, permite com que nessa aplicação, cadastre novas contas, faça login e logout no seu sistema.

</details>

<details>
  <summary><strong>:memo: Habilidades que fram trabalhadas </strong></summary>

Neste projeto, verificamos se você é capaz de:

- Entender sobre as estruturas de array
- Realizar a conversão e manipulação de variáveis de diversos tipos
- Realizar operações aritméticas
- Construir algorítmos que implementem estruturas de controle
- Lançar exceções controladas.


</details>

## Orientações

<details>
  <summary><strong>‼️ 🚀 Como Rodar o Projeto</strong></summary><br />

  1. Clone o repositório

  - Use o comando: `git clone git@github.com:ElielSilva/csharp-001-projeto-trybank.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd csharp-001-projeto-trybank`

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.

  3. Rodar o projeto.
    - Execute o comando: `dotnet run`.

</details>

## Estrutura dos dados

Os dados da conta bancária ficará armazenado em um array multidimensional. Cada array que irá armazenar os dados tem na posição 0 o número da conta, na posição 1, a agencia, na posição 2 a senha de acesso e na posição 3 o saldo da conta. Por exemplo, para cadastro das seguintes contas:

Conta 1: Agência 1, Número da conta: 1234, Senha: 987, Saldo: 0
Conta 2: Agência 2, Número da conta: 5678, Senha: 765, Saldo: 0

O array multidimensional ficaria:

```csharp
    int[] conta1 = new int[4] {1234, 1, 987, 0};
    int[] conta2 = new int[4] {5678, 2, 765, 0};

    int[][] Bank = new int[50][conta1, conta2];
```
