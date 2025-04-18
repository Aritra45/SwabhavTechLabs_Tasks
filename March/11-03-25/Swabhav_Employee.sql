CREATE TABLE DEPERTMENT(DEPTNO INT PRIMARY KEY, DEPTNAME VARCHAR(20), LOCATION VARCHAR(20));
CREATE TABLE EMPLOYEE(EMPID INT PRIMARY KEY, NAME VARCHAR(20), JOBTITLE VARCHAR(20), COMMISION INT NULL, SALARY INT, HIREDATE DATE, DEPTNO INT, FOREIGN KEY (DEPTNO) REFERENCES DEPERTMENT(DEPTNO), MANAGERID INT NULL, FOREIGN KEY (MANAGERID) REFERENCES EMPLOYEE(EMPID));

INSERT INTO DEPERTMENT(DEPTNO, DEPTNAME , LOCATION) VALUES(10, 'ACCOUNTING', 'NEWWORK'), (20, 'SELLS', 'DALLAS'), (30, 'RESEARCH', 'CHICAGO'), (40, 'OPERATIONS', 'BOSTON');

INSERT INTO EMPLOYEE(EMPID, NAME, JOBTITLE, COMMISION, SALARY , HIREDATE , DEPTNO, MANAGERID) VALUES
(101 , 'SMITH' , 'CLERK' , NULL , 10000 , '2024-08-30' , 10, 104 ),
(102 , 'AELLEN' , 'SALESMAN' , 1600 , 5000 , '2023-07-15' , 10 ,104),
(103 , 'BALAKE' , 'MANAGER' , 5000 , 45000 , '2022-06-03' , 10 ,104),
(104 , 'KING' , 'PRESIDENT' , NULL , 80000 , '2020-08-30' , 10 ,NULL ),
(105 , 'ABHISHEK' , 'MANAGER' , 4000 , 50000 , '2022-06-18' , 20 ,104 ),
(106 , 'SCOTT' , 'ANALYAST' , NULL , 30000 , '2023-02-12' , 20 ,105 ),
(107 , 'ARITRA' , 'ANALYAST' , 2000 , 40000 , '2024-01-01' , 30 ,105 ),
(108 , 'PARITOSH' , 'SALESMAN' , 1800 , 35000 , '2024-03-08' , 30 ,103 ),
(109 , 'DEV' , 'CLERK' , NULL , 15000 , '2025-01-10' , 20 ,105 );

SELECT * FROM EMPLOYEE
--#1. Display all employee names in ascending order
SELECT NAME AS EMPLOYEE_NAME
FROM EMPLOYEE
ORDER BY NAME ASC;

--#2. Display all employees(all columns) in department 20 and 30
SELECT * FROM EMPLOYEE E
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO
WHERE E.DEPTNO = 20 OR E.DEPTNO = 30;

--#3. Display all the employees who are managers
SELECT NAME AS EMPLOYEE_NAME
FROM EMPLOYEE
WHERE JOBTITLE = 'MANAGER'

--#4. Display all the employees whose salary is between 2000 and 5000
SELECT NAME AS EMPLOYEE_NAME
FROM EMPLOYEE
WHERE SALARY BETWEEN 2000 AND 5000;

--#5. Display all the employees whose commission is null
SELECT NAME AS EMPLOYEE_NAME
FROM EMPLOYEE
WHERE COMMISION IS NULL;

--#6. Display emp_name,salary,comission,ctc(calculated column)
SELECT NAME AS EMPLOYEE_NAME, SALARY, COMMISION, (SALARY+ ISNULL(COMMISION, 0)*12) AS CTC
FROM EMPLOYEE

--#7. Display hire_date, current_date, tenure(calculated col) of the empl
SELECT NAME AS EMPLOYEE_NAME, HIREDATE, GETDATE() AS CURRENTDATE, DATEDIFF(YEAR, HIREDATE, GETDATE()) AS TENURE
FROM EMPLOYEE

--#8. Display all the employees whose name starts with s
SELECT NAME AS EMPLOYEE_NAME
FROM EMPLOYEE
WHERE NAME LIKE 'S%';

--#9. Display unique department numbers from the employee table
SELECT DISTINCT DEPTNO FROM EMPLOYEE;

--#10 Display emp_name and job in lower case
SELECT LOWER(NAME) AS LOWER_EMPLOYEE_NAME, LOWER(JOBTITLE) AS LOWER_JOB_TITLE
FROM EMPLOYEE;

--#11 Select top 3 salary earning employee
SELECT TOP 3 NAME AS EMPLOYEE_NAME, SALARY
FROM EMPLOYEE
ORDER BY SALARY DESC ;

--#12 Select clerks and Managers in department 10
SELECT NAME AS EMPLOYEE_NAME, JOBTITLE
FROM EMPLOYEE
WHERE JOBTITLE = 'CLERK'
OR JOBTITLE = 'MANAGER'
AND DEPTNO = 10

--#13 Display all clerks in asscending order of the department number 
SELECT NAME AS EMPLOYEE_NAME, JOBTITLE, DEPTNO AS DEPARTMENT_NUMBER
FROM EMPLOYEE
WHERE JOBTITLE = 'CLERK'
ORDER BY DEPTNO ASC;

--#14 Display All employees in the same dept of 'SCOTT' 
SELECT E1.NAME AS EMPLOYEE_NAME, D.DEPTNAME AS DEPARTMENT_NAME
FROM EMPLOYEE E1
JOIN DEPERTMENT D ON E1.DEPTNO = D.DEPTNO
WHERE E1.DEPTNO = (SELECT E2.DEPTNO FROM EMPLOYEE E2 WHERE E2.NAME = 'SCOTT');

--#15 Employees having same designation of SMITH
SELECT NAME AS EMPLOYEE_NAME, JOBTITLE
FROM EMPLOYEE
WHERE JOBTITLE = (SELECT JOBTITLE FROM EMPLOYEE WHERE NAME = 'SMITH');

--#16 Employee who are reproting under KING
SELECT NAME AS EMPLOYEE_NAME, JOBTITLE
FROM EMPLOYEE
WHERE MANAGERID = (SELECT EMPID FROM EMPLOYEE WHERE NAME = 'KING');

--#17 Employees who have same salary of BLAKE
SELECT NAME AS EMPLOYEE_NAME, JOBTITLE, SALARY  
FROM EMPLOYEE  
WHERE SALARY = (SELECT SALARY FROM EMPLOYEE WHERE NAME = 'BALAKE');  

--#18 Display departmentwise number of employees
SELECT D.DEPTNAME AS DEPARTMENT_NAME, COUNT(E.EMPID) AS NUMBER_OF_EMPLOYEES  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO  
GROUP BY D.DEPTNAME;

--#19 Display jobwise number of employees
SELECT JOBTITLE, COUNT(EMPID) AS NUMBER_OF_EMPLOYEES  
FROM EMPLOYEE  
GROUP BY JOBTITLE;

--#20 Display deptwise jobwise number of employees
SELECT D.DEPTNAME AS DEPARTMENT_NAME, E.JOBTITLE, COUNT(E.EMPID) AS NUMBER_OF_EMPLOYEES  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO  
GROUP BY D.DEPTNAME, E.JOBTITLE  
ORDER BY D.DEPTNAME, E.JOBTITLE;

--#21 Display deptwise  employees greater than 3 
SELECT D.DEPTNAME AS DEPARTMENT_NAME, COUNT(E.EMPID) AS NUMBER_OF_EMPLOYEES  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO  
GROUP BY D.DEPTNAME  
HAVING COUNT(E.EMPID) > 3  
ORDER BY NUMBER_OF_EMPLOYEES DESC;

--#22 Display designation wise employees count greater than 3 
SELECT JOBTITLE, COUNT(EMPID) AS NUMBER_OF_EMPLOYEES
FROM EMPLOYEE
GROUP BY JOBTITLE
ORDER BY NUMBER_OF_EMPLOYEES DESC;

--#23 Display Employee name,deptname and location
SELECT E.NAME AS EMPLOYEE_NAME, D.DEPTNAME AS DEPARTMENT_NAME, D.LOCATION  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO;

--#24 Display all deptnames and corresponding employees if ANY
SELECT D.DEPTNAME AS DEPARTMENT_NAME, COALESCE(E.NAME, 'No Employees') AS EMPLOYEE_NAME  
FROM DEPERTMENT D  
LEFT JOIN EMPLOYEE E ON D.DEPTNO = E.DEPTNO  
ORDER BY D.DEPTNAME, E.NAME;

--#25 Dispay all deptnames where there are no employees
SELECT D.DEPTNAME AS DEPARTMENT_NAME  
FROM DEPERTMENT D  
LEFT JOIN EMPLOYEE E ON D.DEPTNO = E.DEPTNO  
WHERE E.EMPID IS NULL;

--#26 Display deptname wise employee count greater than 3, display in descending order of deptname
SELECT D.DEPTNAME AS DEPARTMENT_NAME, COUNT(E.EMPID) AS NUMBER_OF_EMPLOYEES  
FROM DEPERTMENT D  
JOIN EMPLOYEE E ON D.DEPTNO = E.DEPTNO  
GROUP BY D.DEPTNAME  
HAVING COUNT(E.EMPID) > 3  
ORDER BY D.DEPTNAME DESC;

--#27 Display all the empname and their manager names
SELECT E.NAME AS EMPLOYEE_NAME, COALESCE(M.NAME, 'No Manager') AS MANAGER_NAME  
FROM EMPLOYEE E  
LEFT JOIN EMPLOYEE M ON E.MANAGERID = M.EMPID  
ORDER BY MANAGER_NAME, EMPLOYEE_NAME;

--#28 Display empname,deptname and manager name as bossname , order by bossname
SELECT E.NAME AS EMPLOYEE_NAME, D.DEPTNAME AS DEPARTMENT_NAME, COALESCE(M.NAME, 'No Boss') AS BOSS_NAME  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO  
LEFT JOIN EMPLOYEE M ON E.MANAGERID = M.EMPID  
ORDER BY BOSS_NAME, EMPLOYEE_NAME;

--#29 Display Dname, employee name and names of their managers
SELECT D.DEPTNAME AS DEPARTMENT_NAME, E.NAME AS EMPLOYEE_NAME, COALESCE(M.NAME, 'No Manager') AS MANAGER_NAME  
FROM EMPLOYEE E  
JOIN DEPERTMENT D ON E.DEPTNO = D.DEPTNO  
LEFT JOIN EMPLOYEE M ON E.MANAGERID = M.EMPID  
ORDER BY D.DEPTNAME, M.NAME, E.NAME;
