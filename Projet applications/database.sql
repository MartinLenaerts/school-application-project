CREATE TABLE IF NOT EXISTS Client
(
    id        integer PRIMARY KEY,
    nom       TEXT,
    prenom    TEXT,
    ville     TEXT,
    telephone integer,
    dateFirst TEXT,
    numeroRue TEXT,
    rue       TEXT

);

CREATE TABLE IF NOT EXISTS Employee
(
    id     integer PRIMARY KEY,
    nom    TEXT,
    prenom TEXT,
    type   TEXT

);

CREATE TABLE IF NOT EXISTS Facture
(
    id   integer PRIMARY KEY,
    prix NUMERIC

);

CREATE TABLE IF NOT EXISTS Annexe
(
    id     integer PRIMARY KEY,
    nom    TEXT,
    volume NUMERIC,
    prix   NUMERIC

);
CREATE TABLE IF NOT EXISTS Pizza
(
    id     integer PRIMARY KEY,
    nom    TEXT,
    taille TEXT,
    prix   NUMERIC

);
CREATE TABLE IF NOT EXISTS Commande
(
    id          integer PRIMARY KEY,
    heure       TEXT,
    date        TEXT,
    clientId    integer,
    factureId   integer,
    commisId    integer,
    livreurId   integer,
    cuisinierId integer,
    CONSTRAINT clientFk FOREIGN KEY (clientId) REFERENCES Client (id),
    CONSTRAINT factureFk FOREIGN KEY (factureId) REFERENCES Facture (id),
    CONSTRAINT commisFk FOREIGN KEY (commisId) REFERENCES Employee (id),
    CONSTRAINT livreurFk FOREIGN KEY (livreurId) REFERENCES Employee (id),
    CONSTRAINT cuisinierFk FOREIGN KEY (cuisinierId) REFERENCES Employee (id)

);
CREATE TABLE IF NOT EXISTS AnnexeCommande
(
    id         integer PRIMARY KEY,
    annexeId   int,
    commandeId int,
    CONSTRAINT annexeFk FOREIGN KEY (annexeId) REFERENCES Annexe (id),
    CONSTRAINT commandeFk FOREIGN KEY (commandeId) REFERENCES Commande (id)


);
CREATE TABLE IF NOT EXISTS PizzaCommande
(
    id         integer PRIMARY KEY,
    pizzaId    int,
    commandeId int,
    CONSTRAINT pizzaFk FOREIGN KEY (pizzaId) REFERENCES Pizza (id),
    CONSTRAINT commandeFk FOREIGN KEY (commandeId) REFERENCES Commande (id)

);
