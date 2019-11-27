SELECT CarMaker,CarModel,SUM(SalePriceInDollar) AS totalSales
FROM CarSales
WHERE
    SaleDate >= DATEADD(day, -30, GETDATE())
GROUP BY
    CarMaker,
	CarModel