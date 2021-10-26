SELECT DISTINCT customers.ContactName
FROM orders
INNER JOIN customers ON orders.CustomerID=customers.CustomerID
WHERE ((SELECT EmployeeID FROM employees WHERE employees.FirstName='Nancy' AND employees.LastName='Davolio')=EmployeeID);