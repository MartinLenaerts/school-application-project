DELETE
FROM Client;
DELETE
FROM Employee;
DELETE
FROM Annexe;
DELETE
FROM Pizza;
DELETE
FROM Commande;
DELETE
FROM AnnexeCommande;
DELETE
FROM PizzaCommande;

UPDATE `sqlite_sequence`
SET `seq` = 0;

INSERT INTO Client (nom, prenom, ville, telephone, dateFirst, numeroRue, rue)
VALUES ("sarkosy", "nicolas", "PAris", 0101010101, "01/01/2021", "11", "jean jaures"),
       ("macron", "emmanuel", "Paris", 0202020202, "02/02/2022", "12", "jean jaures");

INSERT INTO Employee (nom, prenom, type)
VALUES ("commis1nom", "commis1prenom", "commis"),
       ("livreur1nom", "livreur1prenom", "livreur"),
       ("cuisinier1nom", "cuisinier1prenom", "cuisinier");

INSERT INTO Annexe (nom, prix, volume)
VALUES ("coca", 1.5, 500),
       ("fanta", 1.6, 500),
       ("orangina", 1.7, 500);

INSERT INTO Pizza (nom, prix, taille, type)
VALUES ("quatreFromages petite", 10, "petite", "quatreFromages"),
       ("barbecue petite", 9, "petite", "barbecue"),
       ("veggie petite", 8, "petite", "veggie"),
       ("quatreFromages moyenne", 12, "moyenne", "quatreFromages"),
       ("barbecue moyenne", 11, "moyenne", "barbecue"),
       ("veggie moyenne", 10, "moyenne", "veggie"),
       ("quatreFromages grande", 15, "grande", "quatreFromages"),
       ("barbecue grande", 14, "grande", "barbecue"),
       ("veggie grande", 13, "grande", "veggie");

INSERT INTO Facture (prix)
VALUES (13.1),
       (10.6),
       (8);


INSERT INTO Commande (heure, date, factureId, clientId, commisId, livreurId, cuisinierId)
VALUES ("11h00", "01/02/2020", 1, 1, 1, 2, 3),
       ("12h00", "07/12/2020", 2, 2, 1, 2, 3),
       ("13h00", "09/09/2021", 3, 1, 1, 2, 3);


INSERT INTO AnnexeCommande (annexeId, commandeId)
VALUES (1, 1),
       (2, 2),
       (2, 1);

INSERT INTO PizzaCommande (pizzaId, commandeId)
VALUES (1, 1),
       (2, 2),
       (3, 3);