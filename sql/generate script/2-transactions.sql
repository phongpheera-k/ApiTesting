CREATE TABLE Transactions (
    Transaction_ID int IDENTITY(1,1) CONSTRAINT PK_Transaction PRIMARY KEY,
    Transaction_Date datetime Default GetDate(),
    Customer_ID int NOT NULL,
    Amount dec(8,2),
	Currency_Code varchar(3),
	[Status] tinyint,
	CONSTRAINT FK_CustomerID FOREIGN KEY (Customer_ID) REFERENCES Customers(Customer_ID)
);