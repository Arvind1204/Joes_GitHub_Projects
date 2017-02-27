-- Write queries to return the following:
-- Make the following changes in the "world" database.

-- 1. Add Superman's hometown, Smallville, Kansas to the city table. The 
-- countrycode is 'USA', and population of 45001. (Yes, I looked it up on 
-- Wikipedia.)
INSERT INTO [dbo].[city]
	([name],
	[population],
	[district],
	[countrycode])
VALUES
	('Smallville',45001,'Kansas','USA')

-- 2. Add Kryptonese to the countrylanguage table. Kryptonese is spoken by 0.0001
-- percentage of the 'USA' population.
INSERT INTO [dbo].[countrylanguage]
	([countrycode],
	[isofficial],
	[language],
	[percentage])
VALUES
	('USA',0,'Kryptonese',0.0001)

-- 3. After heated debate, "Kryptonese" was renamed to "Krypto-babble", change 
-- the appropriate record accordingly.
UPDATE [dbo].[countrylanguage]
	SET language = 'Krypto-babble'
	WHERE language = 'Kryptonese'
	GO

-- 4. Set the US captial to Smallville, Kansas in the country table.
UPDATE [dbo].[country]
	SET capital = '4080'
	WHERE code = 'USA'
	GO

-- 5. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
DELETE FROM [dbo].[city]
WHERE name = 'Smallville'
		-- Did not succeed because it's ID is being used in the Country Table as a foreign key.

-- 6. Return the US captial to Washington.
UPDATE [dbo].[country]
	SET capital = '3813'
	WHERE code = 'USA'
	GO

-- 7. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
DELETE FROM [dbo].[city]
WHERE name = 'Smallville'
		-- It succeeded because it is no longer being used in the Country Table as a foreign key.

-- 8. Reverse the "is the official language" setting for all languages where the
-- country's year of independence is within the range of 1800 and 1972 
-- (exclusive). 
-- (590 rows affected)
UPDATE [dbo].[countrylanguage]
	SET isofficial = CASE isofficial WHEN 0 THEN 1 WHEN 1 THEN 0 ELSE isofficial END
	FROM [dbo].[countrylanguage] cl
	join country co ON cl.countrycode = co.code
	WHERE indepyear >= 1800 AND indepyear <= 1972

-- 9. Convert population so it is expressed in 1,000s for all cities. (Round to
-- the nearest integer value greater than 0.)
-- (4068 rows affected)
UPDATE [dbo].[city]
	SET population = (population / 1000)
	WHERE population > 0

-- 10. Assuming a country's surfacearea is expressed in miles, convert it to 
-- meters for all countries where French is spoken by more than 20% of the 
-- population.
-- (7 rows affected)
UPDATE [dbo].[country]
	SET surfacearea = (surfacearea * 1609.34)
	FROM [dbo].[country] as co
	join countrylanguage cl ON co.code = cl.countrycode
	WHERE cl.language = 'French' AND cl.percentage > 20
