USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--populate drink and restaurant data
-- TO POPULATE HARD CODED DATA: 

-- get the file paths to the corresponding files in the database folder and paste them in their correct locations.
-- run the code from here to the end! and that's all folks

USE final_capstone
GO

BEGIN TRANSACTION

DROP TABLE IF EXISTS restaurant_drinks;
DROP TABLE IF EXISTS drinks;
DROP TABLE IF EXISTS restaurants;


CREATE TABLE drinks (
id int IDENTITY (1,1) NOT NULL,
drink_name VARCHAR (50) NOT NULL,
description TEXT,
isFrozen TINYINT NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE restaurants (
id int IDENTITY (1,1) NOT NULL,
name VARCHAR (50) NOT NULL,
zip_code VARCHAR(5) NOT NULL,
PRIMARY KEY (id)
);

CREATE TABLE restaurant_drinks (
drink_id INT NOT NULL,
restaurant_id INT NOT NULL,
PRIMARY KEY (drink_id, restaurant_id),
FOREIGN KEY (drink_id) REFERENCES drinks(id),
FOREIGN KEY (restaurant_id) REFERENCES restaurants(id)
);
COMMIT;
GO

BEGIN TRANSACTION

BULK INSERT dbo.drinks 
FROM "C:\Users\Student\workspace\Partner Projects\c-sharp-finalcapstone-team1\dotnet\database\Drinks.csv"
WITH (FORMAT = 'CSV',
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = ';'
);

BULK INSERT dbo.restaurants
FROM "C:\Users\Student\workspace\Partner Projects\c-sharp-finalcapstone-team1\dotnet\database\Restaurants.csv"
WITH (FORMAT = 'CSV',
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = ';'
);


BULK INSERT dbo.restaurant_drinks
FROM "C:\Users\Student\workspace\Partner Projects\c-sharp-finalcapstone-team1\dotnet\database\drink_restaurant.csv"
WITH (FORMAT = 'CSV',
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = ';'
);


SELECT drinks.id, drink_name, description FROM drinks 
JOIN restaurant_drinks ON drinks.id = restaurant_drinks.drink_id
JOIN restaurants ON restaurants.id = restaurant_drinks.restaurant_id
WHERE name LIKE 'bar%' ;

COMMIT;