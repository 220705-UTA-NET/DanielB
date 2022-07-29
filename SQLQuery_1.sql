CREATE SCHEMA Monster;
GO;

-- DROP Table Monster.Monsters

CREATE TABLE Monster.Monsters
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    MonsterType NVARCHAR(255) NOT NULL 
);

SELECT * FROM Monster.Monsters