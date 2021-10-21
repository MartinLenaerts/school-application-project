BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Client" (
	"id"	INTEGER,
	"nom"	CHAR(50),
	"prenom"	CHAR(50),
	"adresse"	CHAR(200),
	"telephone"	INTEGER,
	"dateFirst"	DATE,
	PRIMARY KEY("id" AUTOINCREMENT)
);
COMMIT;
