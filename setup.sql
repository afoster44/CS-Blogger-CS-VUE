USE bloggeraf;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

CREATE TABLE blogs
(
    id INT AUTO_INCREMENT NOT NULL,
    title VARCHAR(255) NOT NULL,
    body VARCHAR(255) NOT NULL,
    imgurl VARCHAR(255) NOT NULL,
    published TINYINT,
    creatorid VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);