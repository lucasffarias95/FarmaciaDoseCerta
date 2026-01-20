# ?? Farmácia Dose Certa

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/pt-br/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download)

O **Farmácia Dose Certa** é um assistente pessoal de saúde desenvolvido em C#. O objetivo do sistema é ajudar usuários a gerenciarem seus medicamentos, controlarem o estoque e nunca perderem o horário de uma dose.

---

## ?? Demonstração do Projeto

Abaixo, você pode ver o sistema em funcionamento:

![Demonstração do Sistema](./screenshot.png) 
> *Nota: Substitua o arquivo screenshot.png pela captura de tela do seu terminal.*

---

## ?? Funcionalidades

- **Gerenciamento Completo (CRUD):** Cadastre, visualize e remova medicamentos com facilidade.
- **Cálculo de Próxima Dose:** O sistema calcula automaticamente o horário da próxima dose com base no intervalo definido.
- **Controle de Estoque Inteligente:**
- Baixa automática no estoque ao registrar uma dose.
- Sistema de **Alertas Visuais** para medicamentos com estoque baixo.
- Opção de reposição rápida de estoque.
- **Persistência de Dados:** Todos os dados são salvos em um arquivo `dados.json`, garantindo que suas informações estejam lá sempre que você abrir o programa.
- **Tratamento de Erros:** Sistema robusto contra entradas inválidas (letras onde deveriam ser números, etc).

---

## ??? Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET
- **Formato de Dados:** JSON (System.Text.Json)
- **Paradigma:** Programação Orientada a Objetos (POO)

---

## ?? Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone [https://github.com/SEU-USUARIO/FarmaciaDoseCerta.git](https://github.com/SEU-USUARIO/FarmaciaDoseCerta.git)