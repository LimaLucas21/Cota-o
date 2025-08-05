# 💱 Cotação - RPA de Câmbio (Dólar/Euro)

Este projeto foi desenvolvido como parte de um desafio proposto pelo **Grupo Linhares**. O objetivo foi criar uma automação (RPA) capaz de:

* Acessar uma fonte oficial de dados;
* Extrair as cotações do **Dólar** e do **Euro** em relação ao **Real (BRL)**;
* Gerar um **arquivo PDF** contendo essas informações;
* Enviar o PDF para os destinatários definidos (se aplicável).

## 🛠️ Tecnologias utilizadas

* **C#**
* **.NET**
* **Selenium WebDriver**
* **iTextSharp** (para geração do PDF)

## 📄 Objetivo

Automatizar o processo de consulta e geração de relatório das cotações, reduzindo o trabalho manual e garantindo agilidade e precisão nos dados.

## 🚀 Como executar

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/cotacao.git
   ```

2. Abra o projeto no **Visual Studio**.

3. Restaure os pacotes NuGet necessários.

4. Execute o projeto (`F5` ou botão "Iniciar").

## 📌 Observações

* O sistema depende de conexão com a internet para acessar as fontes de cotação.
* Caso ocorra erro ao gerar o PDF, verifique permissões de escrita na pasta de destino.

