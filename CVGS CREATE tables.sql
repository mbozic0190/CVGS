CREATE DATABASE CVGS;

CREATE TABLE platforms (
	platform_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	platform_name VARCHAR(30)
);

CREATE TABLE developers (
	developer_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	developer_name VARCHAR(30)
);

CREATE TABLE categories (
	category_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	category_name VARCHAR(30)
);

CREATE TABLE games (
	game_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	game_name VARCHAR(50),
	description TEXT,
	release_date DATE,
	price MONEY NOT NULL DEFAULT 0,
	category_id INT FOREIGN KEY (category_id) REFERENCES categories(category_id) NOT NULL,
	developer_id INT FOREIGN KEY (developer_id) REFERENCES developers(developer_id) NOT NULL
);

CREATE TABLE game_platforms (
	game_platform_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	game_id INT FOREIGN KEY (game_id) REFERENCES games(game_id) NOT NULL,
	platform_id INT FOREIGN KEY (platform_id) REFERENCES platforms(platform_id) NOT NULL
);

CREATE TABLE users (
	user_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	employee_flag CHAR(1) NOT NULL,
	display_name VARCHAR(50) UNIQUE,
	first_name VARCHAR(25),
	last_name VARCHAR(25),
	birth_date DATE,
	email VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(30) NOT NULL,
	gender CHAR(1),
	promotional_emails CHAR(1),
	category_id INT FOREIGN KEY (category_id) REFERENCES categories(category_id),
	platform_id INT FOREIGN KEY (platform_id) REFERENCES platforms(platform_id),
);

CREATE TABLE wishlists (
	wishlist_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	game_id INT FOREIGN KEY (game_id) REFERENCES games(game_id) NOT NULL
);

CREATE TABLE reviews (
	review_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	game_platform_id INT FOREIGN KEY (game_platform_id) REFERENCES game_platforms(game_platform_id) NOT NULL,
	review_text TEXT,
	validated_flag CHAR(1) NOT NULL,
	validated_by INT FOREIGN KEY (validated_by) REFERENCES users(user_id)
);

CREATE TABLE events (
	event_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	event_date DATE,
	created_by INT FOREIGN KEY (created_by) REFERENCES users(user_id) NOT NULL,
	event_name VARCHAR(50),
	event_description TEXT
);

CREATE TABLE event_registration (
	registration_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	event_id INT FOREIGN KEY (event_id) REFERENCES events(event_id) NOT NULL,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	registration_date DATE
);

CREATE TABLE payment_types (
	payment_type_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	payment_type_description VARCHAR(50),
);

CREATE TABLE orders (
	order_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	order_date DATE,
	payment_type_id INT FOREIGN KEY (payment_type_id) REFERENCES payment_types(payment_type_id) NOT NULL,
	card_number INT,
	billing_address_1 VARCHAR(50),
	billing_address_2 VARCHAR(50),
	billing_city VARCHAR(25),
	billing_province VARCHAR(20),
	billing_country VARCHAR(20),
	billing_postal_code VARCHAR(8),
	billing_first_name VARCHAR(25),
	billing_last_name VARCHAR(25),
	shipping_address_1 VARCHAR(50),
	shipping_address_2 VARCHAR(50),
	shipping_city VARCHAR(25),
	shipping_province VARCHAR(20),
	shipping_country VARCHAR(20),
	shipping_postal_code VARCHAR(8),
	shipping_first_name VARCHAR(25),
	shipping_last_name VARCHAR(25),
);

CREATE TABLE order_shipments (
	order_shipment_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	order_id INT FOREIGN KEY (order_id) REFERENCES orders(order_id) NOT NULL,
	shipped_by INT FOREIGN KEY (shipped_by) REFERENCES users(user_id) NOT NULL,
	shipment_date DATE
);

CREATE TABLE order_details (
	order_detail_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	order_id INT FOREIGN KEY (order_id) REFERENCES orders(order_id) NOT NULL,
	game_platform_id INT FOREIGN KEY (game_platform_id) REFERENCES game_platforms(game_platform_id) NOT NULL,
	physical_copy CHAR(1),
	qty_ordered INT
);

CREATE TABLE order_shipment_details (
	order_shipment_detail_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	order_detail_id INT FOREIGN KEY (order_detail_id) REFERENCES order_details(order_detail_id) NOT NULL,
	qty_ship INT,
	order_shipment_id INT FOREIGN KEY (order_shipment_id) REFERENCES order_shipments(order_shipment_id) NOT NULL,
);

CREATE TABLE user_shipment_info (
	shipment_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	address_1 VARCHAR(50),
	address_2 VARCHAR(50),
	city VARCHAR(25),
	province VARCHAR(20),
	country VARCHAR(20),
	postal_code VARCHAR(8),
	first_name VARCHAR(25),
	last_name VARCHAR(25)
);

CREATE TABLE user_payment_info (
	payment_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	payment_type_id INT FOREIGN KEY (payment_type_id) REFERENCES payment_types(payment_type_id) NOT NULL,
	card_number INT,
	address_1 VARCHAR(50),
	address_2 VARCHAR(50),
	city VARCHAR(25),
	province VARCHAR(20),
	country VARCHAR(20),
	postal_code VARCHAR(8),
	first_name VARCHAR(25),
	last_name VARCHAR(25)
);