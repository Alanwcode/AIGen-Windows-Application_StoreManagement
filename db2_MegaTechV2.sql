create database MegaTechV2;
use MegaTechV2;

create table adminLogin (username varchar(6) primary key, passUser varchar(10));
insert into adminLogin values 
	('adminA', 'adminA@256'), 
	('adminH', 'adminH@123'), 
	('adminU', 'adminU@456'), 
	('adminR', 'adminR@241'), 
	('Sadmin', 'SA@51adm!#');
	
create table customer (NIC varchar(13) primary key, cusName varchar(30), cusAddress varchar(100), email varchar(30), tel varchar(15));
create table customerLogin (username varchar(20) primary key, cusPassword varchar(8), cusNIC varchar(13) foreign key references customer(NIC));
insert into customer values ('0000000000000', 'Demo User', 'demo', 'demo@host.com', '1111111111');
insert into customerLogin values ('demoUser', 'demo@123', '0000000000000');

create table products (prodNumber int identity (1111,1) primary key, 
				color varchar(7), camQuality int, intergration varchar(8), rType varchar(20),
				remoteAccess bit, voiceControl bit, price int);
insert into products (color, rType, camQuality, intergration, remoteAccess, voiceControl, price) 
			values ('White', 'Industrial', 3, 'None', 0, 0, 2360),
			('White', 'Agricultural', 8, 'Siri', 0, 1, 3600),
			('White', 'Industrial', 8, 'Siri', 1, 0, 3990),
			('White', 'Multi Functional', 12, 'Siri', 1, 1, 5399);

create table orders (OID int identity (0001,1) primary key, 
		cusNIC varchar(13) foreign key references customer(NIC), 
		PID int foreign key references products(prodNumber), 
		oDate date default getdate(), deliveryAddress varchar(200));

insert into customerLogin values ('rameshrukshan', 'rar123', '200030100436');

select * from products;
select * from customer;
select * from orders;
select * from adminLogin;
select * from customerLogin;