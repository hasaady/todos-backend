-- Create tables

CREATE TABLE users(
	user_id SERIAL PRIMARY KEY, 
    username VARCHAR(50) NOT NULL UNIQUE, 
    encrypted_password VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL UNIQUE,
    role VARCHAR(50) NOT NULL,
    refresh_token VARCHAR(50),
    expire_date TIMESTAMP
);
