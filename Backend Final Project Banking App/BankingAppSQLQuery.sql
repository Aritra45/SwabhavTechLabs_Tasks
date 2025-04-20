CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    EmployeeFullName NVARCHAR(100),
    EmployeeEmail NVARCHAR(100),
    EmployeeBankAccountNumber NVARCHAR(15),
    EmployeeSalaryAmount DECIMAL(18,2),
    CompanyEmail NVARCHAR(450),
	IsActive bit,
);



-- Sample BULK INSERT for CSV
BULK INSERT Employees
FROM 'E:\Tasks\Backend Final Project Banking App\Employees.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

drop table Employees
drop table Transactions
drop table TransactionTypes
drop table Role
drop table Companies
drop table Beneficiaries
drop table Banks
drop table BankAccountTypes
drop table Users

Insert into Roles(RoleName) values ('Admin')
Insert into Roles(RoleName) values ('Bank')
Insert into Roles(RoleName) values ('Company')

