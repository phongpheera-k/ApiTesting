CREATE TABLE Customers(
	Customer_ID numeric(10,0) IDENTITY(1,1) CONSTRAINT PK_Customer PRIMARY KEY,
	Customer_Name nvarchar(30),
	Contact_Email nvarchar(25),
	Mobile_No nvarchar(10)
);