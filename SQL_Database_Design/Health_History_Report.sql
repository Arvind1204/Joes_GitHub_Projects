BEGIN TRANSACTION

CREATE TABLE Owner (
	owner_id integer identity NOT NULL,
	name varchar(30) NOT NULL,
	CONSTRAINT pk_owner_id PRIMARY KEY (owner_id) 
);

CREATE TABLE Pet (
	pet_id integer identity NOT  NULL,
	name varchar(20) NOT NULL,
	type varchar(20) NOT NULL,
	age integer NOT NULL,
	owner_id integer NOT NULL 
	CONSTRAINT pk_pet_id PRIMARY KEY (Pet_id),
	CONSTRAINT fk_owner_id FOREIGN KEY (owner_id) REFERENCES Owner(Owner_id)
);

CREATE TABLE Visit (
	visit_id integer identity NOT NULL,
	Date DateTime NOT NULL,
	pet_id integer NOT NULL,
	CONSTRAINT pk_visit_id PRIMARY KEY (Visit_id),
	CONSTRAINT fk_pet_id FOREIGN KEY (pet_id) REFERENCES Pet(pet_id),
);

CREATE TABLE ProcedureT (
	procedure_id integer identity NOT NULL,
	Description varchar(100),
	CONSTRAINT pk_procedure_id PRIMARY KEY (procedure_id),
);

CREATE TABLE Procedures_Performed (
	procedure_performed_id integer identity NOT NULL,
	visit_id integer NOT  NULL,
	procedure_id integer NOT NULL,
	CONSTRAINT pk_procedure_performed_id PRIMARY KEY (procedure_performed_id),
	CONSTRAINT fk_visit_id FOREIGN KEY (visit_id) REFERENCES Visit(visit_id),
	CONSTRAINT fk_procedure_id FOREIGN KEY (procedure_id) REFERENCES ProcedureT(procedure_id),
);


COMMIT TRANSACTION;