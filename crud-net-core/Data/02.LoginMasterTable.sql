create table LoginMaster (
	LoginId int primary key identity(1,1),
	UserName nvarchar(50) unique,
	UserPassword nvarchar(20) unique,
	CreatedDate datetime2 default(GETDATE()),
	CreatedBy varchar(10) default('SYS Admin')
)
