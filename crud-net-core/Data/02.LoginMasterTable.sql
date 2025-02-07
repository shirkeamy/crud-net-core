create table LoginMaster (
	LoginId int primary key identity(1,1),
	UserName nvarchar(50) unique,
	UserPassword nvarchar(20) unique,
	CreatedDate datetime2 default(GETDATE()),
	CreatedBy varchar(10) default('SYS Admin')
)
GO

insert into LoginMaster (UserName, UserPassword) values
('sam@email.com', 'password'),
('john@example.com', 'StrongPassword'),
('joe@email.com', 'Y0urStr0ngPass0rd')