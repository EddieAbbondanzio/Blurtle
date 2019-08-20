CREATE TABLE Post (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    UserId INT,
    Type TINYINT NOT NULL,
    Title VARCHAR(300) NOT NULL,
    Body VARCHAR(10000) NOT NULL,
    CreationDate DateTime NOT NULL,
    WasUpdated BOOLEAN,
    WasDeleted BOOLEAN,
    CommentCount INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES User(Id)
);
