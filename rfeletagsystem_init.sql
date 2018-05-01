drop database if exists rfet;

create database rfet;

USE rfet;


DROP TABLE if exists `Role`;
DROP TABLE if exists `User`;
DROP TABLE if exists `Medicine`;
DROP TABLE if exists `AddressMapping`;
DROP TABLE if exists `SystemConfig`;
DROP TABLE if exists `TakeMedicineTask`;
DROP TABLE if exists `TakeMedicineTaskItem`;
DROP TABLE if exists `AddMedicineTask`;
DROP TABLE if exists `AddMedicineTaskItem`;

CREATE TABLE Role(
    Id integer PRIMARY KEY auto_increment,
    Name VARCHAR(32) NOT NULL,
    Display_en_US VARCHAR(255),
    Display_zh_CN VARCHAR(255),
    Display_zh_TW VARCHAR(255)
);

CREATE TABLE User(
    Id integer PRIMARY KEY auto_increment,
    Name VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Role integer,
    FOREIGN KEY(Role) REFERENCES Role(Id)
);

CREATE TABLE Medicine(
    Id integer PRIMARY KEY auto_increment,
    Name VARCHAR(255) NOT NULL,
    Guid integer not null unique,
    Description VARCHAR(255)
);

CREATE TABLE AddressMapping(
    Id integer PRIMARY KEY auto_increment,
    Address VARCHAR(32) NOT NULL unique,
    Guid integer not null unique,
    FOREIGN KEY(Guid) REFERENCES Medicine(Guid)
);

CREATE TABLE SystemConfig (
    Id integer primary key auto_increment,
    K VARCHAR(255),
    V VARCHAR(255)
);

create table TakeMedicineTask(
    Id integer primary key auto_increment,
	Name varchar(255) not null,
	Items_All integer,
    Items_Complete integer,
    Manager integer,
    Operator integer,
	State varchar(32),
	FOREIGN KEY(Manager) REFERENCES User(Id),
	FOREIGN KEY(Operator) REFERENCES User(Id)
);

create table TakeMedicineTaskItem(
    Id integer primary key auto_increment,
	Task integer,
	Medicine integer,
    Amount integer,
	State integer,
	FOREIGN KEY(Task) REFERENCES TakeMedicineTask(Id),
	FOREIGN KEY(Medicine) REFERENCES Medicine(Id)
);

create table AddMedicineTask(
    Id integer primary key auto_increment,
	Name varchar(255) not null,
	Items_All integer,
    Items_Complete integer,
    Manager integer,
    Operator integer,
	State varchar(32),
	FOREIGN KEY(Manager) REFERENCES User(Id),
	FOREIGN KEY(Operator) REFERENCES User(Id)
);

create table AddMedicineTaskItem(
    Id integer primary key auto_increment,
	Task integer,
	Medicine integer,
    Amount integer,
	State integer,
	FOREIGN KEY(Task) REFERENCES AddMedicineTask(Id),
	FOREIGN KEY(Medicine) REFERENCES Medicine(Id)
);

insert into Role(Id,Name,Display_en_US,Display_zh_CN,Display_zh_TW)
values
    (1,'ADMIN','Admin','管理员','管理员'),
    (2,'DOCTOR','Doctor','医生','医生'),
    (3,'NURSE','Nurse','护士','护士'),
    (4,'ITSUP','ITSupport','IT支持','IT支持'),
    (5,'PHARM','Pharmaceutist','药剂师','药剂师');

insert into User(Id,Name,Password,Role)
values
    (1,'Zhang','123456',1),
    (2,'Wang','123456',2),
    (3,'Li','123456',3),
    (4,'Zhao','123456',4),
    (5,'Liu','123456',5);

insert into SystemConfig(Id,K,V)
values
    (1,'Serial.portName','COM1'),
    (2,'Serial.baudRate','9600'),
    (3,'Serial.dataBits','8'),
    (4,'Serial.parity','None'),
    (5,'Serial.stopBits','1');

insert into Medicine(Id,Name,Guid,Description)
values
	(1,"麦迪霉素",1,"麦迪霉素"),
	(2,"复方新诺明",2,"复方新诺明"),
	(3,"诺氟沙星",3,"诺氟沙星"),
	(4,"乙酰螺旋霉素",4,"乙酰螺旋霉素"),
	(5,"黄连素",5,"黄连素"),
	(6,"克霉唑",6,"克霉唑"),
	(7,"多酶片",7,"多酶片"),
	(8,"复合维生素Ｂ",8,"复合维生素Ｂ"),
	(9,"吗丁啉",9,"吗丁啉");
	
insert into TakeMedicineTask(Id,Name,Items_All,Items_Complete,Manager,Operator,State)
values
	(1,"take_task_1",10,0,2,2,"InProcess"),
	(2,"take_task_2",20,0,2,2,"NotStarted"),
	(3,"take_task_3",99,0,2,3,"NotStarted"),
	(4,"take_task_4",18,0,2,3,"Completed"),
	(5,"take_task_5",9,0,2,3,"Completed");

insert into TakeMedicineTaskItem(Id,Task,Medicine,Amount,State)
values
    (1,1,1,2,0),
	(2,2,2,5,0),
	(3,2,3,7,0),
	(4,3,4,1,0),
	(5,3,5,6,0),
	(6,3,6,4,0),
	(7,4,7,2,0),
	(8,4,8,19,0),
	(9,5,9,11,0);
	

insert into AddMedicineTask(Id,Name,Items_All,Items_Complete,Manager,Operator,State)
values
	(1,"add_task_1",10,0,2,2,"InProcess"),
	(2,"add_task_2",20,0,2,2,"NotStarted"),
	(3,"add_task_3",99,0,2,3,"NotStarted"),
	(4,"add_task_4",18,0,2,3,"Completed"),
	(5,"add_task_5",9,0,2,3,"Completed");

insert into AddMedicineTaskItem(Id,Task,Medicine,Amount,State)
values
    (1,1,1,7,0),
	(2,2,2,15,0),
	(3,2,3,22,0),
	(4,3,4,9,0),
	(5,3,5,13,0),
	(6,3,6,8,0),
	(7,4,7,4,0),
	(8,4,8,3,0),
	(9,5,9,1,0);


use `rfeletagsystem`;	  /*你的数据库名*/
set global optimizer_switch='derived_merge=OFF';














