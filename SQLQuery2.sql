create database CarRentalSystem
use CarRentalSystem


create table Categories
(
	CategoryID int primary key Identity(1,1),
	CategoryName varchar(50),
	SeatingCapacity int
);

create table Cars
(
	CarID int primary key Identity(1,1),
	Brand varchar(50),
	ModelName varchar(50),
	CategoryID int,
	Constraint fk_CatID Foreign key (CategoryID) references Categories(CategoryID),
	Car_Status varchar(50) check(Car_Status in ('Rented','Available')),
	Fuel_Type varchar(50) check(Fuel_Type in ('Diesel','Petrol')),
	CarPricePerHour float,
);

 create table Customers
 (
	UserID int primary key Identity(1,1),
	UserName varchar(50),
	License_Number varchar(50),
	UserPassword varchar(50),
	PhoneNumber int,
	Email varchar(50)
);

create table Rental (
 RentalID int primary key Identity(1,1), 
 CarID int,
 Constraint fk_carID Foreign Key(CarID) references Cars(CarID),
 UserID int,
 Constraint fk_userID Foreign Key (UserID) references Customers(UserID),
 StartDateTime Datetime,
 EndDateTime Datetime,
 Price float
 );

 select * from Customers;
 select * from Cars;
 select * from Categories;
 select * from Rental;

update Cars set Brand = 'suzuki', ModelName  = 'X7', CategoryID = 2, Car_Status = 'Available' , Fuel_Type = 'Diesel' , CarPricePerHour = 500  where CarID = 2;

select UserID from Customers where Email = 'arpit';

select UserName from Customers where UserID = 6
ALTER TABLE Cars drop CONSTRAINT fk_CatID; 
ALTER TABLE Cars ADD CONSTRAINT fk_CatID FOREIGN KEY (CategoryID)REFERENCES Categories(CategoryID)ON DELETE CASCADE ON UPDATE NO ACTION;

update Cars 

alter table Rental drop Constraint fk_userID;
Alter table Rental add Constraint fk_userID foreign key (UserID) references Customers(UserID) on DELETE CASCADE ON UPDATE NO ACTION;

select * from Customers where UserID = 2 and UserPassword = 'password';

select datediff(hour , '2022-08-03 12:00:00','2022-08-03 13:00:00') ;

select Car_status from Cars where CarId = 1;

select Count(*) from Cars where CarID  = 2;

select UserID,UserName,License_Number,PhoneNumber,Email from Customers;

delete from Categories where CategoryID = 7;

select Count(*) from Categories where CategoryId = 3;