DROP DATABASE IF EXISTS dssistemas_db;
CREATE DATABASE dssistemas_db;
USE dssistemas_db;

CREATE TABLE sexo (
    cod_sex int not null auto_increment,
    nome_sex varchar(100) not null,
    primary key (cod_sex)
);

CREATE TABLE produto (
    cod_prod int not null auto_increment,
    nome_prod varchar(100) not null,
    unidade_prod int not null,
    valor_compra_prod decimal(15, 2) not null,
    primary key (cod_prod)
);

CREATE TABLE endereco (
    cod_end int not null auto_increment,
    rua_end varchar(255) not null,
    numero_end int not null,
    bairro_end varchar(255) not null,
    cidade_end varchar(255) not null,
    estado_end varchar(255) not null,
    primary key (cod_end)
);

CREATE TABLE funcionario (
    cod_func int not null auto_increment,
    nome_func varchar(100) not null,
    cpf_func varchar(20) not null,
    rg_func varchar(50) not null,
    datanasc_func date not null,
    email_func varchar(100) not null,
    celular_func varchar(50) not null,
    funcao_func varchar(50) not null,
    salario_func decimal(15, 2) not null,
    cod_sex_fk int not null,
    cod_end_fk int not null,
    primary key (cod_func),
    foreign key (cod_sex_fk) references sexo (cod_sex),
    foreign key (cod_end_fk) references endereco (cod_end)
);

CREATE TABLE fornecedor (
    cod_forn int not null auto_increment,
    razaosocial_forn varchar(255) not null,
    nomefantasia_forn varchar(255) not null,
    cnpj_forn varchar(20) not null,
    telefone_forn varchar(50) not null,
    representante_forn varchar(255) not null,
    cod_end_fk int null,
    primary key (cod_forn),
    foreign key (cod_end_fk) references endereco (cod_end)
);

CREATE TABLE compra (
    cod_comp int not null auto_increment,
    data_comp date not null,
    forma_pagamento_comp varchar(255) not null,
    valor_total_comp decimal(15, 2) not null,
    cod_func_fk int not null,
    cod_forn_fk int not null,
    primary key (cod_comp),
    foreign key (cod_func_fk) references funcionario (cod_func),
    foreign key (cod_forn_fk) references fornecedor (cod_forn)
);

CREATE TABLE itens_compra (
    cod_itenc int not null auto_increment,
    quantidade_itenc int not null,
    valor_itenc decimal(15, 2) not null,
    valor_total_itenc decimal(15, 2) not null,
    cod_comp_fk int not null,
    cod_prod_fk int not null,
    primary key (cod_itenc),
    foreign key (cod_comp_fk) references compra(cod_comp),
    foreign key (cod_prod_fk) references produto(cod_prod)
);

CREATE TABLE usuario (
    cod_usu int not null auto_increment,
    usuario_usu varchar(255) not null,
    senha_usu varchar(255) not null,
    cod_func_fk int,
    primary key (cod_usu),
    foreign key (cod_func_fk) references funcionario (cod_func)
);

INSERT INTO sexo VALUES (null, 'Masculino'), (null, 'Feminino');
INSERT INTO produto VALUE (null, 'PLACA MÃE - I7 11G', 10, 1600.35);
INSERT INTO produto VALUE (null, 'PLACA MÃE - I5 11G', 10, 980.35);
INSERT INTO produto VALUE (null, 'MONITOR LCD 24" 60HZ', 10, 1500.00);
INSERT INTO produto VALUE (null, 'MONITOR LCD 27" 144HZ', 10, 2500.00);

INSERT INTO endereco VALUE (null, 'Rua ABC', 4391, 'Jd. dos Migrantes', 'Ji-Paraná', 'Rondônia');
INSERT INTO funcionario VALUE (null, 'João Teixeira', '123.456.789-00', '100355 SESDEC/RO', '1986-11-13', 'joao.teixeira@ifro.edu.br', '(69) 2183-6901', 'Financeiro', 6500.85, 1, 1);

INSERT INTO fornecedor VALUES (null, 'TROPICAL TECH LTDA', 'TROPICAL TECH', '01.789.567/0001-05', '(69) 99999-2020', 'João da Silva', null);
INSERT INTO fornecedor VALUES (null, 'TECH MIX DISTRIBUIDORA LTDA', 'TECH MIX DISTRIBUIDORA', '01.123.567/0001-34', '(69) 99999-1010', 'Pedro Pereira', null);

INSERT INTO usuario VALUE (null, 'joao', '123456', 1);
