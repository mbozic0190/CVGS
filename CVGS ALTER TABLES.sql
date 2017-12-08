CREATE TABLE payment_types (
	payment_type_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	payment_type_description VARCHAR(50),
);

ALTER TABLE orders 
	ADD payment_type_id INT FOREIGN KEY (payment_type_id) REFERENCES payment_types(payment_type_id),
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
	shipping_last_name VARCHAR(25);

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