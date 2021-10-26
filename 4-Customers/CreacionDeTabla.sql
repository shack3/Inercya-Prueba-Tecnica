CREATE SCHEMA `BaseDatos`;

CREATE TABLE BaseDatos.customers(
	Id INTEGER UNIQUE NOT NULL,
    Name VARCHAR(30) NOT NULL,
    Address VARCHAR(30) NOT NULL,
	City VARCHAR(30) NOT NULL,
    Country VARCHAR(30) NOT NULL,
    PostalCode INTEGER,
    Phone VARCHAR(30)
);