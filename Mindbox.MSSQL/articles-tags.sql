-- Мог накосячить с Naming Conventions, ибо работаю с MSSQL всего пару часов.
-- До этого все время работал на PostgreSQL

-- DDL для MSSQL

CREATE TABLE dbo.Article (
    Id INT IDENTITY PRIMARY KEY,
    Topic VARCHAR,
);

CREATE TABLE dbo.Tag (
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR
);

CREATE TABLE dbo.ArticleTag (
    Id INT IDENTITY,
    TagId INT REFERENCES dbo.Tag (Id),
    ArticleId INT REFERENCES dbo.Article (Id)
);

-- SQL запрос для выбора всех пар «Тема статьи – тэг». Если у статьи нет тэгов, то её тема всё равно выводится

SELECT
    A.Topic,
    T.Name
FROM dbo.Article A
    LEFT JOIN ArticleTag AT ON A.Id = AT.ArticleId
    LEFT JOIN Tag T ON AT.TagId = T.Id;