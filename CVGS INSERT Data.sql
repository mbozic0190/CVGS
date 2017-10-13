
INSERT INTO platforms VALUES
	('PC');
INSERT INTO platforms VALUES
	('XboxOne');
INSERT INTO platforms VALUES
	('PS4');

INSERT INTO developers VALUES
	('Blizzard');
INSERT INTO developers VALUES
	('CD Projekt RED');
INSERT INTO developers VALUES
	('Bungie');
INSERT INTO developers VALUES
	('Monolith Productions');
INSERT INTO developers VALUES
	('ConcernedApe');

INSERT INTO categories VALUES
	('Action');
INSERT INTO categories VALUES
	('FPS');
INSERT INTO categories VALUES
	('RPG');
INSERT INTO categories VALUES
	('Simulator');

INSERT INTO games VALUES
	('Stardew Valley', 'Stardew Valley is an indie farming simulation role-playing video game developed by Eric "ConcernedApe" Barone and published by Chucklefish. The game is open-ended, allowing the player to take on activities as they see fit.', '2016-02-26', 14.99 , 4, 5);
INSERT INTO games VALUES
	('Overwatch', 'Overwatch is a team-based multiplayer online first-person shooter video game developed and published by Blizzard Entertainment.', '2016-05-24', 59.99, 2, 1);
INSERT INTO games VALUES
	('The Witcher 3', 'The Witcher® 3: Wild Hunt is a story-driven, next-generation open world role-playing game, set in a visually stunning fantasy universe, full of meaningful choices and impactful consequences. You play as Geralt of Rivia, a monster hunter tasked with finding a child from an ancient prophecy.', '2015-05-19', 39.99, 3, 2);
INSERT INTO games VALUES
	('Destiny 2', 'Players assume the role of a Guardian, protectors of Earths last safe city as they wield a power called Light to protect the Last City from different alien races.', '2017-10-24', 59.99, 2, 3);
INSERT INTO games VALUES
	('Middle-Earth: Shadow of War', ' The player continues the story of the ranger Talion and the spirit of the elf lord Celebrimbor, who shares Talions body, as they forge a new Ring of Power to amass an army to fight against Sauron.', '2017-10-10', 59.99, 1, 4);

INSERT INTO game_platforms VALUES
	(1, 1);
INSERT INTO game_platforms VALUES
	(1, 2);
INSERT INTO game_platforms VALUES
	(1, 3);
INSERT INTO game_platforms VALUES
	(2, 1);
INSERT INTO game_platforms VALUES
	(2, 2);
INSERT INTO game_platforms VALUES
	(2, 3);
INSERT INTO game_platforms VALUES
	(3, 1);
INSERT INTO game_platforms VALUES
	(3, 2);
INSERT INTO game_platforms VALUES
	(3, 3);
INSERT INTO game_platforms VALUES
	(4, 1);
INSERT INTO game_platforms VALUES
	(4, 2);
INSERT INTO game_platforms VALUES
	(4, 3);
INSERT INTO game_platforms VALUES
	(5, 1);
INSERT INTO game_platforms VALUES
	(5, 2);
INSERT INTO game_platforms VALUES
	(5, 3);

INSERT INTO users (employee_flag, display_name, first_name, last_name, email, password) VALUES 
	('Y', 'mbozic', 'Mirko','Bozic', 'mbozic0927@conestogac.on.ca', 'Password1');
INSERT INTO users (employee_flag, display_name, first_name, last_name, email, password) VALUES 
	('Y', 'jkosterman', 'Jacob','Kosterman', 'jkosterman6222@conestogac.on.ca', 'Password2');
INSERT INTO users (employee_flag, display_name, first_name, last_name, email, password) VALUES 
	('Y', 'kjuffs', 'Kelsey','Juffs', 'kjuffs6256@conestogac.on.ca', 'Password3');
INSERT INTO users (employee_flag, display_name, first_name, last_name, email, password) VALUES 
	('Y', 'skereliuk', 'Sydney','Kereliuk', 'skereliuk????@conestogac.on.ca', 'Password4');
INSERT INTO users (employee_flag, display_name, first_name, last_name, birth_date, email, password, gender, promotional_emails, category_id, platform_id) VALUES 
	('N', 'vwolfmoon ', 'Volkor','Wolfmoon', '1990-01-24', 'wolfmoon@email.ca', 'Password5', 'M', 'Y', 2, 1);


INSERT INTO reviews (user_id, game_platform_id, review_text, validated_flag) VALUES
	(5, 3, 'Great game', 'P');

INSERT INTO events VALUES
	('2017-10-24', 1, 'Destiny 2 Midnight Release', 'Destiny 2 Midnight Release');

INSERT INTO event_registration VALUES
	(1, 5, '2017-10-10');

INSERT INTO orders VALUES
	(5, '2017-10-10');

INSERT INTO order_shipments VALUES
	(1, 1, '2017-10-11');

INSERT INTO order_details VALUES
	(1, 3, 'Y', 1);

INSERT INTO order_shipment_details VALUES
	(1, 1, 1);