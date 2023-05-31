--CREATE DATABASE ECommerceDB
USE ECommerceDB
Go
CREATE TABLE [tblUsers](
	UserId bigint Identity(1,1) PRIMARY KEY,
	FirstName varchar(50) not null,
	LastName varchar(80),
	Email varchar(255) not null,
	[Password] varchar(255) not null,
	PhoneNumber varchar(16) not null,
	IsActive bit default 1,
	CountryId tinyint not null,
	CityId int not null,
	ProfileImg varchar(500),
	RoleId tinyint default 1,
	CreatedAt DateTime default current_timestamp,
	UpdatedAt DateTime,
	DeletedAt DateTime,
	FOREIGN KEY(CountryId) REFERENCES tblCountries(CountryId),
	FOREIGN KEY(CityId) REFERENCES tblCities(CityId),
	FOREIGN KEY(RoleId) REFERENCES tblRoles(RoleId),
);
drop table tblUsers
CREATE TABLE [tblCountries](
	CountryId tinyint Identity(1,1) PRIMARY KEY,
	[CountryName] varchar(60) not null,
	IsActive bit default 1,
);
CREATE TABLE [tblCities](
	CityId int Identity(1,1) PRIMARY KEY,
	[CityName] varchar(90) not null,
	IsActive bit default 1,
	CountryId tinyint, 
	FOREIGN KEY(CountryId) REFERENCES tblCountries(CountryId),
);
CREATE TABLE [tblRoles](
	RoleId tinyint Identity(1,1) PRIMARY KEY,
	[Role] varchar(25) not null,
	IsActive bit default 1,
);
CREATE TABLE [tblCategories](
	CategoryId smallint Identity(1,1) PRIMARY KEY,
	[CategoryName] varchar(50) not null,
	IsActive bit default 1,
);
CREATE TABLE [tblSubCategories](
	SubCategoryId INT Identity(1,1) PRIMARY KEY,
	[SubCategoryName] varchar(50) not null,
	IsActive bit default 1,
	CategoryId smallint,
	FOREIGN KEY(CategoryId) REFERENCES tblCategories(CategoryId),
);
---todo:
CREATE TABLE [tblSuppliers](
	SupplierId bigint Identity(1,1) PRIMARY KEY,
	SupplierName varchar(100) not null,
	ContactNumber varchar(16) not null, 
	ContactEmail varchar(255) not null,
	IsActive bit default 1,
	[CreatedAt] DateTime default current_timestamp,
	[UpdatedAt] DateTime,
	[DeletedAt] DateTime,
);
CREATE TABLE [tblCompanies](
	[CompanyId] bigint Identity(1,1) PRIMARY KEY,
	[CompanyName] varchar(100) not null,
	[CompanyAddress] varchar(255) not null,
	[ContactEmail] varchar(255) not null,
	[CountryId] tinyint,
	[IsActive] bit default 1,
	[CreatedAt] DateTime default current_timestamp,
	FOREIGN KEY(CountryId) REFERENCES tblCountries(CountryId),
);
--CREATE TABLE [Inventories] (
--  InventoryId INT Identity(1,1) PRIMARY KEY,    
--  InventoryName varchar(50) not null,
--  CountryId TINYINT, --FK
--  CityId INT, --FK
--  ProcessingTime TIME, --Number of days to deliever the product
--  ShippingTime INT, --Number of days to deliever the product
--  IsAvailable bit default 1,--available
--  FOREIGN KEY(CountryId) REFERENCES tblCountries(CountryId),
--  FOREIGN KEY(CityId) REFERENCES tblCities(CityId),
--  --Capacity bigint not null,
--);

CREATE TABLE [tblProductSupplierMapping](
	ProductId bigint not null,
	SupplierId bigint, --supplier may not be available
	AvailableStocks int,
	PRIMARY KEY(ProductId,SupplierId)
);
CREATE TABLE [tblProducts] (
  [ProductId] BIGINT IDENTITY(1,1) PRIMARY KEY,
  [ProductName] VARCHAR(255) NOT NULL,
  [Description] VARCHAR(2000),
  [SKU] VARCHAR(50) NOT NULL,
  [Price] DECIMAL(10, 2) DEFAULT 0 ,
  [Discount] DECIMAL(5,2) DEFAULT 0,
  [IsFree] BIT NOT NULL,--CHECK FROM FORM IF TRUE THEN PRICE 0 ELSE PRICE REQUIRED
  [CategoryId] SMALLINT, --FK
  [SubCategoryId] INT, --Fk
  [CompanyId] bigint, --FK
  CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  UpdatedAt DATETIME,
  DeletedAt DATETIME,
  FOREIGN KEY(CompanyId) REFERENCES tblCompanies(CompanyId),
  FOREIGN KEY(CategoryId) REFERENCES tblCategories(CategoryId),
  FOREIGN KEY(SubCategoryId) REFERENCES tblSubCategories(SubCategoryId),
);

CREATE TABLE [tblProductMedia](
	MediaId bigint Identity(1,1) PRIMARY KEY,
	[MeidaName] varchar(255),
	[MediaUrl] varchar(500) not null,
	[MediaType] varchar(20) not null,
	IsDefault bit default 0,
	[ProductId] bigint not null, --FK
	CreatedAt DateTime default current_timestamp,
	UpdatedAt DateTime,
	DeletedAt DateTime,
	FOREIGN KEY(ProductId) REFERENCES tblProducts(ProductId),
);
CREATE TABLE [tblProductRatings](
	RatingId bigint Identity(1,1) PRIMARY KEY,
	[Ratings] tinyint,
	[UserId] bigint not null, --FK
	ProductId bigint not null,--FK
	CreatedAt DateTime default current_timestamp not null,
	UpdatedAt DateTime,
	FOREIGN KEY(UserId) REFERENCES tblUsers(UserId),
	FOREIGN KEY(ProductId) REFERENCES tblProducts(ProductId),
);
CREATE TABLE [tblProductReviews](
	[ProductReviewId] bigint Identity(1,1) PRIMARY KEY,
	[Description] varchar(1000) not null,
	[UserId] bigint not null, --FK
	[ProductId] bigint not null,--FK
	[CreatedAt] DateTime default current_timestamp,
	[UpdatedAt] DateTime,
	[DeletedAt] DateTime,
	FOREIGN KEY(UserId) REFERENCES tblUsers(UserId),
	FOREIGN KEY(ProductId) REFERENCES tblProducts(ProductId),
);
CREATE TABLE [tblProductReviewMedia](
	[ReviewMediaId] bigint Identity(1,1) PRIMARY KEY,
	[MeidaName] varchar(255),
	[MediaUrl] varchar(500) not null,
	[MediaType] varchar(20) not null,
	[ProductReviewId] bigint not null, --FK
	CreatedAt DateTime default current_timestamp,
	UpdatedAt DateTime,
	DeletedAt DateTime,
	FOREIGN KEY(ProductReviewId) REFERENCES tblProductReviews(ProductReviewId),
);
CREATE TABLE [tblCarts](
	CartId bigint Identity(1,1) PRIMARY KEY,
	UserId bigint ,   --FK
	ProductId bigint not null,--FK
	Quantity tinyint default 1,
	TotalAmount decimal(12,2),
	IsRemoved bit default 0,
	FOREIGN KEY(UserId) REFERENCES tblUsers(UserId),
	FOREIGN KEY(ProductId) REFERENCES tblProducts(ProductId),
);
CREATE TABLE [tblOrders](
	OrderId bigint Identity(1,1) PRIMARY KEY,
	ProductId bigint not null, --FK
	UserId bigint not null,--FK
	Quantity tinyint default 1,
	TotalAmountPaid decimal(10,2),
	[PaymentMethodId] tinyint not null, --FK
	[UserAddressId] bigint not null,--FK
	[SupplierId] bigint not null,
	[OrderedAt] DateTime default current_timestamp,
	[CanceledAt] DateTime,
	FOREIGN KEY(UserId) REFERENCES tblUsers(UserId),
	FOREIGN KEY(ProductId) REFERENCES tblProducts(ProductId),
	FOREIGN KEY(PaymentMethodId) REFERENCES tblPaymentMethods(PaymentMethodId),
	FOREIGN KEY(UserAddressId) REFERENCES tblUserAddresses(UserAddressId),
	FOREIGN KEY(SupplierId) REFERENCES tblSuppliers(SupplierId),
);
CREATE TABLE [tblPaymentMethods](
	PaymentMethodId tinyint Identity(1,1) PRIMARY KEY,
	[PaymentMethodName] varchar(25) not null,
	IsActive bit default 1,
);
CREATE TABLE [tblUserAddresses](
	UserAddressId bigint Identity(1,1) PRIMARY KEY,
	[AddressLine1] varchar(100) not null,
	[AddressLine2] varchar(100),
	[UserId] bigint not null, --FK
	CountryId tinyint not null, --FK
	CityId int not null, --FK
	PostalCode tinyint,
	IsDeleted bit default 0,
	FOREIGN KEY(UserId) REFERENCES tblUsers(UserId),
	FOREIGN KEY(CountryId) REFERENCES tblCountries(CountryId),
	FOREIGN KEY(CityId) REFERENCES tblCities(CityId),
);

drop table [Users]
drop table [Roles]
drop table [Countries]
drop table [Cities]
drop table [ProductMedia]
drop table [Companies]
drop table [SubCategories]
drop table [Products]




------------Constraints Implementation-----------------
ALTER TABLE [Users]
ADD CONSTRAINT fk_Users_RoleId_Roles
FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
GO
ALTER TABLE [Users]
ADD CONSTRAINT fk_Users_CountryId_Countries
FOREIGN KEY (CountryId) REFERENCES Countries(CountryId)
GO
ALTER TABLE [Users]
ADD CONSTRAINT fk_Users_CityId_Cities
FOREIGN KEY (CityId) REFERENCES Cities(CityId)
GO
ALTER TABLE [Cities]
ADD CONSTRAINT fk_Cities_CountryId_Countries
FOREIGN KEY (CountryId) REFERENCES Countries(CountryId)
GO
ALTER TABLE [SubCategories]
ADD CONSTRAINT fk_SubCategories_CategoryId_Categories
FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
GO

------------Insert Operations--------------------------
INSERT INTO [Roles] ([Role],IsActive) VALUES('User',1)
INSERT INTO [Roles] ([Role],IsActive) VALUES('Supplier',1)
INSERT INTO [Roles] ([Role],IsActive) VALUES('Admin',1)


INSERT INTO [ProductMedias] ([MediaPath],IsDefault,ProductId) VALUES('~/Assests/ProductImages/product1.jpg',1,1)

