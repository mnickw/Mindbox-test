SELECT P.Name AS ProductName, C.Name AS CategoryName
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON C.Id = PC.CategoryId;