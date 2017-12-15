CREATE TABLE shopping_cart(
	shopping_cart_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT FOREIGN KEY (user_id) REFERENCES users(user_id) NOT NULL,
	platform_id INT FOREIGN KEY (platform_id) REFERENCES platforms(platform_id),
	quantity INT);