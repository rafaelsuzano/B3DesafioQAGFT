Feature: Correios

Utilizando uma linguagem de automação, preferência, C#(Specflow e NUnit), crie um script que realize os seguintes passos:
1.	Entre no site dos correios;
2.	Procure pelo CEP 80700000;
3.	Confirmar que o CEP não existe;
4.	Voltar a tela inicial;
5.	Procure pelo CEP 01013-001
6.	Confirmar que o resultado seja em “Rua Quinze de Novembro, São Paulo/SP”
7.	Voltar a tela inicial;
8.	Procurar no rastreamento de código o número “SS987654321BR”
9.	Confirmar que o código não está correto;
10.	Fechar o browser;



@tag1
Scenario:  Consult  CEP not valid and valid tracking
	Given  that I'm on the website of the correios
	When     have an not valid  CEP
	Then   the site returns invalid cep
	Then   that I'm on the mail site I'll do new search
	And    have an valid  CEP
	Then   the site returns valid cep
	Then    I return on the website of the Correios
	Then   I Consult a tracking code




