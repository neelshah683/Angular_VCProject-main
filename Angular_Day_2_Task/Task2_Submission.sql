CREATE TABLE customer (
   customer_id serial PRIMARY KEY,
   first_name character varying(100) NOT NULL,
   last_name character varying(100) NOT NULL,
   email character varying(255) UNIQUE NOT NULL,
   created_date timestamp with time zone NOT NULL DEFAULT now(),
   updated_date timestamp with time zone
);

CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date timestamp with time zone NOT NULL DEFAULT now(),
    order_number CHARACTER VARYING(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);

select * from orders;


select * from customer;

ALTER TABLE customer ADD COLUMN active boolean;

ALTER TABLE customer DROP COLUMN active;

ALTER TABLE customer RENAME COLUMN email TO email_address;

ALTER TABLE customer RENAME COLUMN email_address TO email;

/* Insert into customer table as a single record */
INSERT INTO customer(first_name, last_name, email, created_date, updated_date, active)
	VALUES ('Bansi','Sachade','.bansi.sachade@tatvasoft.com',now(),NULL,true);

/* Insert into customer table as a multiples record */
INSERT INTO customer (first_name, last_name, email, created_date, updated_date,active) VALUES
  ('John', 'Doe', 'johndoe@example.com', NOW(), NULL,true),
  ('Alice', 'Smith', 'alicesmith@example.com', NOW(), NULL,true),
  ('Bob', 'Johnson', 'bjohnson@example.com', NOW(), NULL,true),
  ('Emma', 'Brown', 'emmabrown@example.com', NOW(), NULL,true),
  ('Michael', 'Lee', 'michaellee@example.com', NOW(), NULL,false),
  ('Sarah', 'Wilson', 'sarahwilson@example.com', NOW(), NULL,true),
  ('David', 'Clark', 'davidclark@example.com', NOW(), NULL,true),
  ('Olivia', 'Martinez', 'oliviamartinez@example.com', NOW(), NULL,true),
  ('James', 'Garcia', 'jamesgarcia@example.com', NOW(), NULL,false),
  ('Sophia', 'Lopez', 'sophialopez@example.com', NOW(), NULL,false),
  ('Jennifer', 'Davis', 'jennifer.davis@example.com', NOW(), NULL,true),
  ('Jennie', 'Terry', 'jennie.terry@example.com', NOW(), NULL,true),
  ('JENNY', 'SMITH', 'jenny.smith@example.com', NOW(), NULL,false),
  ('Hiren', 'Patel', 'hirenpatel@example.com', NOW(), NULL,false);

/* Insert into orders table as a multiple record*/
INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);

select * from orders;

select * from customer;

UPDATE customer SET first_name='bansi', last_name='sachade', email='bansi.sachade@tatvasoft.com'
WHERE customer_id = 1;

DELETE FROM customer WHERE customer_id = 11;

SELECT first_name FROM customer;

/* exclude use of DESC, if you want data in ascending order */
SELECT first_name, last_name FROM customer ORDER BY first_name DESC;

SELECT customer_id,	first_name,	last_name FROM customer ORDER BY first_name ASC, last_name DESC;

/* Data Filtering using WHERE Clause */
SELECT 	customer_id, first_name, last_name FROM customer WHERE first_name = 'Hiren' AND last_name = 'Parejiya';

/* IN Operator*/
SELECT customer_id,	first_name,	last_name FROM customer WHERE first_name IN ('John','David','James');

/*LIKE Operator*/
SELECT first_name, last_name FROM customer WHERE first_name LIKE '%EN%';

/*JOIN Query*/
/* INNER JOIN - Intersection */
/* LEFT JOIN - Left Records Match with Right Table Records*/
/* RIGHT JOIN - Right Match with Left Records */
/* FULL JOIN - Left with Right && Right with Left and others contains NULL */

SELECT * FROM orders as o LEFT JOIN customer as c ON o.customer_id = c.customer_id;

/* GROUPING DATA */

SELECT 	c.customer_id, c.first_name, c.last_name, c.email,	COUNT (o.order_id) AS "NoOrders",
	SUM(o.order_amount) AS "Total" FROM customer as c
	INNER JOIN orders as o 	ON c.customer_id = o.customer_id
	GROUP BY c.customer_id;

/* SUB Query */

SELECT * from orders where customer_id IN (select customer_id from customer where active = true);

