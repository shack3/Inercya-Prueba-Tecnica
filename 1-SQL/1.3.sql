SELECT YEAR(orders.OrderDate) AS Year, SUM(db_inercya.`order details`.UnitPrice) AS Factured
FROM orders
INNER JOIN db_inercya.`order details` ON orders.OrderID=db_inercya.`order details`.OrderID
WHERE ((SELECT EmployeeID FROM employees WHERE employees.FirstName='Steven' AND employees.LastName='Buchanan')=EmployeeID)
GROUP BY Year
;