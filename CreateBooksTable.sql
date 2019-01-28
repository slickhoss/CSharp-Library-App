CREATE TABLE Books (bookId INT IDENTITY(1,1) PRIMARY KEY, 
					sku varchar(255), title varchar(255), author varchar(255), genre varchar(255), publisher varchar(255) NULL, publishedYear int NULL, checkedOut bit DEFAULT 0,dateCheckedOut DATETIME NULL, dueDate DATETIME NULL)
					ALTER TABLE Books ADD checkedOutUserLogin VARCHAR(255);