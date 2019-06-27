CREATE TABLE User (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(24) NOT NULL UNIQUE,
    Email VARCHAR(64) UNIQUE,
    PasswordHash CHAR(60) NOT NULL
);
