CREATE TABLE sharpautos (
         id int NOT NULL AUTO_INCREMENT,
         title VARCHAR(255),
         make VARCHAR(255),
         model VARCHAR(255),
         color VARCHAR(255),
         autodescription VARCHAR(255),
         imageurl VARCHAR(255),
         price DECIMAL,
         PRIMARY KEY (id)
      );