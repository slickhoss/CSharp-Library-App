CREATE TABLE Account (userId INT NOT NULL PRIMARY KEY IDENTITY(1,1),email VARCHAR(255), userLogin VARCHAR(255), password VARCHAR(255));
ALTER TABLE Account ALTER COLUMN password NVARCHAR(255) COLLATE Latin1_General_CS_AS
ALTER TABLE Account ADD CONSTRAINT userLogin UNIQUE(Name);