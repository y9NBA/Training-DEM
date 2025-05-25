USE TestDEM;
GO

CREATE TABLE [User] (
	id int PRIMARY KEY IDENTITY(1,1),
	username nvarchar(25) UNIQUE NOT NULL,
	password nvarchar(100) NOT NULL,
	role_name nvarchar(20) default 'BUYER'
)

CREATE TABLE [Good_Type] (
	id int PRIMARY KEY IDENTITY(1,1),
	name nvarchar(30) UNIQUE NOT NULL
)

CREATE TABLE [Good] (
	id int PRIMARY KEY IDENTITY(1,1),
	name nvarchar(255) NOT NULL,
	description nvarchar(MAX),
	type_id int,
	price decimal(18,0) NOT NULL,
	amount int default 0,
	seller_id int,
	sell_count int default 0,
	FOREIGN KEY (type_id) REFERENCES Good_Type(id) ON DELETE CASCADE,
	FOREIGN KEY (seller_id) REFERENCES [User](id) ON DELETE CASCADE
)

CREATE TABLE [Personal] (
	id int PRIMARY KEY IDENTITY(1,1),
	second_name nvarchar(30) NOT NULL,
	first_name nvarchar(30) NOT NULL,
	patronymic nvarchar(30),
	number_phone nvarchar(14) UNIQUE NOT NULL,
	email nvarchar(100) UNIQUE,
	address nvarchar(MAX),
	user_id int,
	FOREIGN KEY (user_id) REFERENCES [User](id) ON DELETE CASCADE
)

CREATE TABLE [Order] (
	id int PRIMARY KEY IDENTITY(1,1),
	user_id int,
	total_price decimal(18,0),
	status nvarchar(20) default 'NEW',
	created_at datetime default GETDATE(),
	FOREIGN KEY (user_id) REFERENCES [User](id) ON DELETE CASCADE
)

CREATE TABLE [Order_Good] (
	id int PRIMARY KEY IDENTITY(1,1),
	order_id int,
	good_id int,
	amount int default 1,
	price decimal(18,0),
	FOREIGN KEY (order_id) REFERENCES [Order](id) ON DELETE CASCADE,
	FOREIGN KEY (good_id) REFERENCES Good(id) ON DELETE NO ACTION
)

