CREATE TABLE sharpautos (
         id int NOT NULL AUTO_INCREMENT,
         title VARCHAR(255) NOT NULL,
         make VARCHAR(255) NOT NULL,
         model VARCHAR(255) NOT NULL,
         color VARCHAR(255) NOT NULL,
         autodescription VARCHAR(255),
         imageurl VARCHAR(255),
         price DECIMAL NOT NULL,
         PRIMARY KEY (id)
      );
    --   fix decimal rounding