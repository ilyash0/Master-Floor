CREATE TABLE IF NOT EXISTS product_type 
(
    product_type_id SERIAL PRIMARY KEY,
    product_type_name VARCHAR(50) NOT NULL,
    product_type_coeficent NUMERIC(3, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS product
(
    product_id SERIAL PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    min_cost NUMERIC(6, 2) NOT NULL,
    product_type_id INT NOT NULL REFERENCES product_type(product_type_id)
);

CREATE TABLE IF NOT EXISTS partner_type (
    partner_type_id SERIAL PRIMARY KEY,
    partner_type_name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS partner (
    partner_id SERIAL PRIMARY KEY,
    partner_name VARCHAR(100) NOT NULL,
    director VARCHAR(100) NOT NULL,
    email VARCHAR(50) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    address VARCHAR(200) NOT NULL,
    inn VARCHAR(15) NOT NULL,
    rating INT2 NOT NULL,
    partner_type_id INT NOT NULL REFERENCES partner_type(partner_type_id)
);

CREATE TABLE IF NOT EXISTS partner_product (
    partner_product_id SERIAL PRIMARY KEY,
    partner_id INT NOT NULL REFERENCES partner(partner_id),
    product_id INT NOT NULL REFERENCES product(product_id),
    sale_timestamp TIMESTAMP NOT NULL,
    quantity INT NOT NULL
);