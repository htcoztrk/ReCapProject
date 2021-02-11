CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(50),
)

CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(50),
)

CREATE TABLE Cars(
	CarId int PRIMARY KEY IDENTITY(1,1),
	CarName nvarchar(50),
	BrandId int,
	ColorId int,
	DailyPrice decimal,
	ModelYear int,
	Descriptions nvarchar(50),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)