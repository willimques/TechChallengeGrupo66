using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Data.Sql
{
    internal class create_sql
    {


        //-- Criar a tabela DDD com a coluna ddd como única
        //CREATE TABLE DDD(
        //    id INT PRIMARY KEY NOT NULL,
        //        estado VARCHAR(2) NOT NULL,
        //        regiao INT NOT NULL,

        //);

        //-- Criar a tabela CONTATOS e definir a chave estrangeira para a coluna ddd na tabela DDD
        //CREATE TABLE CONTATOS(
        //    id INT PRIMARY KEY IDENTITY(1,1),
        //    Nome VARCHAR(200) NOT NULL,
        //    Email VARCHAR(200) NOT NULL,
        //    DDD_ID INT NOT NULL,
        //    Telefone VARCHAR(20) NOT NULL,
        //    CONSTRAINT FK_CONTATOS_DDD FOREIGN KEY(DDD_ID) REFERENCES DDD(id)
        //);


        //        INSERT INTO DDD(estado, id, regiao) VALUES
        //-- Região Norte
        //('AC', 68, 1),
        //('AP', 96, 1),
        //('AM', 92, 1),
        //('AM', 97, 1),
        //('PA', 91, 1),
        //('PA', 93, 1),
        //('PA', 94, 1),
        //('RO', 69, 1),
        //('RR', 95, 1),
        //('TO', 63, 1),

        //-- Região Nordeste
        //('AL', 82, 2),
        //('BA', 71, 2),
        //('BA', 75, 2),
        //('BA', 77, 2),
        //('CE', 85, 2),
        //('CE', 88, 2),
        //('MA', 98, 2),
        //('MA', 99, 2),
        //('PB', 83, 2),
        //('PE', 81, 2),
        //('PE', 87, 2),
        //('PI', 86, 2),
        //('PI', 89, 2),
        //('RN', 84, 2),
        //('SE', 79, 2),

        //-- Região Centro-Oeste
        //('DF', 61, 3),
        //('GO', 62, 3),
        //('GO', 64, 3),
        //('MT', 65, 3),
        //('MT', 66, 3),
        //('MS', 67, 3),

        //-- Região Sudeste
        //('ES', 27, 4),
        //('ES', 28, 4),
        //('MG', 31, 4),
        //('MG', 32, 4),
        //('MG', 38, 4),
        //('MG', 34, 4),
        //('RJ', 21, 4),
        //('RJ', 22, 4),
        //('RJ', 24, 4),
        //('SP', 11, 4),
        //('SP', 19, 4),
        //('SP', 17, 4),
        //('SP', 13, 4),

        //-- Região Sul
        //('PR', 41, 5),
        //('PR', 43, 5),
        //('PR', 44, 5),
        //('RS', 51, 5),
        //('RS', 54, 5),
        //('RS', 53, 5),
        //('SC', 48, 5),
        //('SC', 47, 5),
        //('SC', 49, 5);




    }
}
