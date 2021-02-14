CREATE TABLE Users(
    UserId int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	Password nvarchar(50)
)
CREATE TABLE Customers(
   CustomerId int PRIMARY KEY IDENTITY(1,1),
   UserId int,
   CompanyName nvarchar(50)
   FOREIGN KEY (UserId) REFERENCES Users(UserId)
)
CREATE TABLE Rentals(
  RentalId int PRIMARY KEY IDENTITY(1,1),
  CarId int,
  CustomerId int,
  RentDate datetime,
  ReturnDate datetime,
  FOREIGN KEY (CarId) REFERENCES Cars(CarId),
  FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
)