# desafio-veronez
Desafio Veronez

## A demanda
Deverá ser criada uma aplicação de gerenciamento de **autores** e **obras**, seguindo as regras de relacionamento abaixo:
 - Cada autor poderá ter 0 (zero) ou n obra(s);
 - Cada obra deverá ter 1 (um) ou n autor(es);
 - A partir de uma obra deverá ser posível acessar o(s) autor(es);
 - A partir de um autor deverá ser possível acessar a(s) obra(s).

###  1) Back-end
A aplicação, a ser desenvolvida, deverá expor uma API REST de cadastro, alteração, remoção e consulta de **autores** e **obras** com as seguintes propriedades básicas definidas para cada entidade:

#### Autor
 - Nome - obrigatório
 - Sexo
 - E-mail - não obrigatório, deve ser validado caso preenchido (não pode haver dois cadastros com mesmo e-mail)
 - Data de nascimento - obrigatório, deve ser validada
 - País de origem - obrigatório (deve ser um país existente)
 - CPF - somente deve ser informado caso país de origem seja o Brasil, desta forma torna-se obrigatório. Deve ser validado (formatado e não pode haver dois cadastros com mesmo CPF)

#### Obra
 - Nome - obrigatório
 - Descrição - obrigatório (deve conter no máximo 240 caracteres)
 - Data de publicação - obrigatória caso a data de exposição não seja informada (é utilizada mais para livros e demais publicações escritas)
 - Data de exposição - obrigatória caso a data de publicação não seja informada (é utilizada mais para obras que são expostas, como pinturas, esculturas e demais)

#### Regra(s)
 - A data de publicação e a data de exposição não podem ser nulas ao mesmo tempo, devendo sempre uma ou outra ser informada.

