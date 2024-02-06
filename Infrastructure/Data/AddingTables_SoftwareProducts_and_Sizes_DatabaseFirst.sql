
DROP TABLE SoftwareProducts
DROP TABLE Sizes




CREATE TABLE Sizes (
	
	Id int Primary key IDENTITY(1,1),
	Quantity int not null,
	Unit varchar(10) not null
)

CREATE TABLE SoftwareProducts(
	
	Id int Primary key IDENTITY(1,1),
	Title nvarchar(100) not null,
	SizeId int not null,
	Foreign Key (SizeId) References Sizes(Id)

)