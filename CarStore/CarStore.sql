create table Cars(
    Id int primary key identity(1, 1),
    Brand nvarchar(100) not null,
    Model nvarchar(100) not null,
    Year date not null,
    FuelTypeId int not null,
    BodyTypeId int not null,
    ColorId int not null,
    ImageLink nvarchar(500) not null,
    foreign key (FuelTypeId) references FuelTypes(Id),
    foreign key (BodyTypeId) references BodyTypes(Id),
    foreign key (ColorId) references Colors(Id)
);

create table Users(
    Id int primary key identity(1, 1),
    Username nvarchar(50) not null,
    Password nvarchar(50) not null,
    Email nvarchar(100) not null
);

create table ProductList(
    Id int primary key identity(1, 1),
    CarId int not null,
    SellerId int not null,
    Price decimal(8, 2) not null check(Price >= 0 and Price <= 50000000),
    Quantity int not null,
    foreign key (CarId) references Cars(Id),
    foreign key (SellerId) references Sellers(Id)
);

create table ManufacturingCountries(
    Id int primary key identity(1, 1),
    CountryName nvarchar(100) not null
);

create table FuelTypes(
    Id int primary key identity(1, 1),
    FuelType nvarchar(50) not null
);

create table BodyTypes(
    Id int primary key identity(1, 1),
    BodyType nvarchar(50) not null
);

create table Colors(
    Id int primary key identity(1, 1),
    ColorName nvarchar(50) not null
);

create table Sellers(
    Id int primary key identity(1, 1),
    UserId int not null,
    CompanyName nvarchar(100) not null,
    ContactNumber nvarchar(20) not null,
    CountryId int not null,
    Rating decimal(1, 1) not null check(Rating >= 0 and Rating <= 5),
    foreign key (UserId) references Users(Id),
    foreign key (CountryId) references ManufacturingCountries(Id)
);