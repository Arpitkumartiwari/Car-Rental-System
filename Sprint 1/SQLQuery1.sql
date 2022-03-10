create database CarRentalDB

use CarRentalDB

create table Rental (
 RentalID int primary key, 
 CarID int,
 Constraint fk_carID Foreign Key(CarID) references Cars(CarID),
 UserID int,
 Constraint fk_userID Foreign Key (UserID) references Customers(UserID),
 StartDateTime Datetime,
 EndDateTime Datetime,
 Price float
 );


 create table Customers
 (
	UserID int primary key,
	UserName varchar(50),
	License_Number varchar(50),
	UserPassword varchar(50),
	PhoneNumber int,
	Email varchar(50)
);

create table Cars
(
	CarID int primary key,
	Brand varchar(50),
	ModelName varchar(50),
	CategoryID int,
	Constraint fk_CatID Foreign key (CategoryID) references Categories(CategoryID),
	Car_Status varchar(50) check(Car_Status in ('Rented','Available')),
	Fuel_Type varchar(50) check(Fuel_Type in ('Diesel','Petrol')),
	CarPricePerHour float,
);

create table Categories
(
	CategoryID int primary key,
	CategoryName varchar(50),
	SeatingCapacity int
);
select * from Cars;
select * from Categories;
select * from Customers;
select * from Rental;

drop table Categories

delete from Customers where UserID = 3;

alter table Categories.CategoryId identity(1,1);

create table buildings
( building_no int primary key not null
);

CREATE TABLE rooms 
( room_no INT PRIMARY KEY identity(1,1), 
room_name VARCHAR(255) NOT NULL, 
building_no INT NOT NULL, 
FOREIGN KEY (building_no) REFERENCES buildings (building_no) 
ON DELETE CASCADE )

select * from rooms;

insert into rooms values ('room3',3);

delete from rooms where room_no= 1;

ALTER TABLE Cars drop CONSTRAINT fk_CatID; 
ALTER TABLE Cars ADD CONSTRAINT fk_CatID FOREIGN KEY (CategoryID)REFERENCES Categories(CategoryID)ON DELETE CASCADE ON UPDATE NO ACTION;


