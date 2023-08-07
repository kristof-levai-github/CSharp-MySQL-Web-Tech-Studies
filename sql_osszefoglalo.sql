CREATE DATABASE test; --create db

USE test; --use db

SELECT DATABASE(); --select current db

DROP DATABASE IF EXISTS test; --delete the selected db if it exists 


--ATOMIC TABLES and table templating 
-- each table should only define 1 thing | table describe 1 thing -> what things you need to describe that thing -> then it can crawl and loop thru very fast 
--(pl: students a main thing, azon belül ID,SEX, etc)

--some other rules: normalize tables | dont include multiple values in one cell | dont have multiple clomuns with the same sort of information 

CREATE TABLE student(

    first_name VARCHAR(30) NOT NULL, --max 30 characters, must exist (not null)
    last_name VARCHAR(30) NOT NULL,
    email VARCHAR(60),
    street VARCHAR(50) NOT NULL, 
    city VARCHAR(40) NOT NULL,
    state CHAR(2) NOT NULL DEFAULT "PA", --must contain 2 characters, must exist, default will be PA if not provided 
    phone VARCHAR(20) NOT NULL,
    birth_date DATE NOT NULL, 
    sex ENUM('M', 'F') NOT NULL, 
    date_entered TIMESTAMP, 
    lunch_cost FLOAT NULL, 
    student_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY
);

--whats a PRIMARY KEY and their rules? 
--unique identifies a row/record | each primary key must be unique to the row | must have a given value when db is created (can't be null) | original value can't be changed | auto increment the value of a key 


--DATA TYPES: 
    --NUMERIC TYPES: 
        -- TINTYINT: 127-128
        -- SMALLINT: 32,768 - 32767
        -- MEDIUM INT: 8,388,608 - 8,388,608
        -- INT: 2^31
        --BIGINT 
        --FLOAT
        --DOUBLE

    --STRING TYPES: 
        -- CHAR
        -- VARCHAR
        -- BLOB
        --ENUM
        --SET

    -- DATE AND TIME TYPES:
        -- DATE: yyyy--mm--dd
        -- TIME: hh:mm:ss
        -- DATETIME: yyyy-mm-dd hh:mm:ss
        -- TIMESTAMP: yyyymmddhhmmss
        -- YEAR: yyyy

DESCRIBE test; --description of db 

INSERT INTO student VALUE
    ('Dale', 'Cooper', 'dcooper@aol.com','123 main st', 'Yakima', 'WA', 98901, '792-223-8901', '1959-2-22', 'M', 3.50, NULL); --filling up student db with data


SELECT * FROM student; --select every query from student db 
SELECT date_entered FROM student; --select only data_entered

--creating other classes 
CREATE TABLE class(

    name VARCHAR(30) NOT NULL,
    class_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY

);

--and filling other classes
INSERT INTO class VALUES
    ('English', NULL),
    ('Literature', NULL),
    ('Algebra', NULL),
    ('Art', NULL),
    ('Chemistry', NULL),
    ('Physics ', NULL),
    ('Gym', NULL);

SELECT * FROM class;



CREATE TABLE test(

    date DATE NOT NULL,
    type ENUM('T', 'Q') NOT NULL,
    class_id INT UNSIGNED NOT NULL,
    test_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY

);

--Foreign Key: references to the Primary Key of another table 
    --can have different name form primary key name 
    --doesn't have to be unique 
    --can have NULL value 


CREATE TABLE score(

    student_id INT UNSIGNED NOT NULL, 
    event_id INT UNSIGNED NOT NULL, 
    score INT NOT NULL, 
    PRIMARY KEY(event_id, student_id) --not a unique id, but combined it is unique (foreign)

);


CREATE TABLE absence(

    student_id INT UNSIGNED NOT NULL, 
    date DATE NOT NULL, 
    PRIMARY KEY(student_id ,date)

);

--adding another table to an existing db without creating new (after type -> default its added to the end of db  )
ALTER TABLE test
ADD maxscore INT NOT NULL AFTER type;


INSERT INTO test VALUES
    ('2014-8-25', 'Q', 15, 1, NULL);


SELECT * FROM test;

--change the event_id into test_id 
ALTER TABLE score
    CHANGE event_id test_id INT UNSIGNED NOT NULL;


INSERT INTO absence VALUES
    (1, '2014-08-29');

--multiple values can be selected
SELECT first_name, last_name FROM student;


--show all tables
show tables;

--show a single table 
show table;

--renaming a table 
RENAME TABLE absence TO absences, class TO classes, score TO scores, test TO tests;


--SEARCH QUERIES (logical operators)

--limit the search (WHERE)
SELECT first_name, last_name, state FROM students WHERE state="WA";

--AND statement 
SELECT first_name, last_name, state FROM students WHERE state="WA" AND WHERE YEAR(birth_date) >= 1965;

--OR statement 
SELECT first_name, last_name, state FROM students WHERE state="WA" OR WHERE YEAR(birth_date) >= 2000;

--NOT statement
SELECT first_name, last_name, state FROM students WHERE state="WA" NOT WHERE YEAR(birth_date) >= 2000;

/*
OR = ||
AND = &&
NOT = !
*/

--IS NULL, IS NOT NULL 
SELECT first_name, last_name, state FROM students WHERE last_name IS NULL;
SELECT first_name, last_name, state FROM students WHERE last_name IS NOT NULL;


--ORDER DATA 
SELECT first_name, last_name FROM students ORDER BY last_name;

--DESC = reverse alphabetical order
SELECT first_name, last_name FROM students ORDER BY last_name DESC;


--LIMIT the data you get 
--first 5 here
SELECT first_name, last_name FROM students LIMIT 5;

--5th to 10th 
SELECT first_name, last_name FROM students LIMIT 5, 10;


--CONCAT, AS
--saves first and last name as one query named 'Name'
SELECT CONCAT(first_name, " ", last_name) AS 'Name';


--LIKE (similarity, start, end mostly)
-- 'D%' = starts with D, '%n' = ends with n || _ = represents 1 character 
SELECT last_name, first_name FROM students WHERE first_name LIKE 'D%' OR last_name LIKE '%n';


--DISTINCT = only show 1 matching queries 
SELECT DISTINCT state FROM students ORDER BY state;

--COUNT = for counting the matching queries 
SELECT COUNT(DISTINCT state) FROM students;

SELECT COUNT(*) FROM students WHERE sex='M';

--group the males and the females separately 
SELECT sex, COUNT(*) FROM students GROUP BY sex;

--HAVING (here, shows the amount of students that are from 1 state if its greater than 1)
SELECT state, COUNT(state) AS 'Amount' FROM students GROUP BY state HAVING Amount > 1;


--MIN, MAX, SUM, AVG
SELECT test_id AS 'test',
MIN(score) AS 'min', 
MAX(score) AS 'max', 
AVG(score) AS 'avg',
SUM(score) AS 'total',
MAX(score) - MIN(score) AS 'range' FROM scores GROUP BY test_id;


-- OTHER BUILT IN NUMERIC FUNCTIONS -- 

/*
    ABS(),
    ACOS(), ASIN(), ATAN(), ATAN2(), COS(), SIN(), TAN()
    CEILING(),
    DEGREES(),
    EXP(),
    FLOOR(),
    MOD(),
    LOG(),
    PI(),
    POWER(),
    RAND().
    RADIANS(),
    ROUND(),
    SQRT(),
    STD(),
    TRUNCATE(),

only listed what arent listed above */

--DELETE something from a table 
DELETE FROM absences WHERE student_id = 6; 

--MODIFY table 

ALTER TABLE absences MODIFY COLUMS test_taken ENUM('T', 'F') NOT NULL DEFAULT 'F';

--narrow results: IN ('given value1', 'given value2') -> checks for those in table | BETWEEN (5, 10) -> checks between values 


-- JOINING DATA TOGETHER --

SELECT student_id, date, score, maxscore FROM tests, scores WHERE date='2014-08-25' AND tests.test_id = scores.test_id;

SELECT scores.student_id, test.date, scores.score, tests.maxscore FROM test, scores WHERE date='2014-08-25' AND tests.test_id = scores.test_id;

SELECT students.student_id, CONCAT(student.first_name, " ", students.last_name) AS Name, COUNT(absences.date) AS absences FROM students, absences WHERE students.student_id = absences.student_id GROUP BY students.student_id;

#39.perc 