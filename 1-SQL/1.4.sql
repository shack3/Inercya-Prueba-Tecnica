WITH RECURSIVE emp
AS(
		SELECT EmployeeID, FirstName, LastName, ReportsTo 
		FROM employees
		WHERE FirstName='Andrew' AND LastName='Fuller'
UNION ALL
		SELECT e.EmployeeID, e.FirstName, e.LastName, e.ReportsTo 
		FROM emp
        INNER JOIN employees e ON emp.EmployeeID = e.ReportsTo
)
SELECT FirstName, LastName FROM emp;