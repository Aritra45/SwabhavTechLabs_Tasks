CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    EmployeeFullName NVARCHAR(100),
    EmployeeEmail NVARCHAR(100),
    EmployeeBankAccountNumber NVARCHAR(15),
    EmployeeSalaryAmount DECIMAL(18,2),
    CompanyEmail NVARCHAR(450),
	FOREIGN KEY (CompanyEmail) REFERENCES Companies(CompanyEmail)
);

ALTER TABLE Employees
ADD IsActive bit;

-- Sample BULK INSERT for CSV
BULK INSERT Employees
FROM 'E:\Tasks\Backend Final Project Banking App\Employees.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
