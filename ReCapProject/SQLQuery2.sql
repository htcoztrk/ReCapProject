CREATE TABLE Cars(
Id int PRIMARY KEY IDENTITY(1,1),
BrandId int,
ColorId int,
ModelYear nvarchar(25),
DailyPrice decimal,
Descriptions nvarchar(25),
FOREIGN KEY (BrandID) REFERENCES Brands(BrandId),
FOREIGN KEY (ColorID) REFERENCES Colors(ColorId)
)
INSERT INTO Colors(ColorName) VALUES ('Sarı'),('Lacivert'),('Siyah');
INSERT INTO Brands(BrandName) VALUES ('Audi'),('TOGG'),('Toyota');
INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions) VALUES 
('1','2','2012','100','Otomatik Vites'),
('1','3','2015','160','Manuel Benzin'),
('2','1','2017','300','Manuel Dizel'),
('3','3','2020','200','Otomatik Hybrid');