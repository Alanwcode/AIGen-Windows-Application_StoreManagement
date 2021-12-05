create database MegaTech;
use MegaTech;

create table adminLogin (username varchar(6) primary key, passUser varchar(10));
insert into adminLogin values 
	('adminA', 'adminA@256'), 
	('adminH', 'adminH@123'), 
	('adminU', 'adminU@456'), 
	('adminR', 'adminR@241'), 
	('Sadmin', 'SA@51adm!#');

create table Customer (NIC varchar(13), cusName varchar(30), cusAddress varchar(50), 
	email varchar(30), tel varchar(15), username varchar(20), cusPassword varchar(8),
	primary key (NIC, username));

insert into Customer values ('0000000000000', 'Demo User', 'demo', 'demo@host.com', '1111111111', 'demoUser', 'demo@123');

create table customProducts (prodNumber int identity (1111,1) primary key, 
				color varchar(7), camQuality int, intergration varchar(8), 
				remoteAccess bit, voiceControl bit, price int);

create table Orders (OID int identity (0001,1) primary key, 
		cusNIC varchar(13), 
		PID int foreign key references customProducts(prodNumber), 
		oDate date default getdate(), deliveryAddress varchar(200));

insert into customProducts(color, camQuality, intergration, remoteAccess, voiceControl, price) 
			values ('White', 3, 'None', 0, 0, 2360),
			('White', 12, 'Siri', 0, 1, 3600),
			('White', 3, 'Siri', 1, 0, 3990),
			('White', 8, 'Siri', 1, 1, 5399);

select * from Customer;
select * from adminLogin;
select * from customProducts;
select * from Orders;
