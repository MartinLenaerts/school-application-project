using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Projet_applications;

namespace Projet_applications
{
    public class Commis : Employee
    {
        public String MsgClient()
        {
            // TODO implement here
            return null;
        }


        public String MsgCuisine()
        {
            // TODO implement here
            return null;
        }


        public String MsgLivreur()
        {
            // TODO implement here
            return null;
        }


        public String MsgCommis()
        {
            // TODO implement here
            return null;
        }


        /* public null recupererEtat() {
             // TODO implement here
             return null;
         }*/
        public void DemanderFacture()
        {
            // TODO implement here
        }

        public void Encaisser()
        {
            // TODO implement here
        }

        public void FermerCommande()
        {
            CurrentCommande.Etat = Etat.Ferme;
        }


        public int GererCumul()
        {
            // TODO implement here
            return 0;
        }


        public Facture GenererFacture()
        {
            // TODO implement here
            return null;
        }


        public void CreerCommande(Database database)
        {
            Console.WriteLine("Entrez le numero de telephone du client : ");
            string tel = Console.ReadLine();
            String query = "SELECT * FROM client where telephone=" + tel;
            SQLiteCommand idCommand = new SQLiteCommand(query, database.myConnection);
            SQLiteDataReader reader = idCommand.ExecuteReader();
            CurrentCommande = new Commande();
            if (!reader.HasRows)
            {
                CurrentCommande.Client = AjouterClient(database);
            }
            else
            {
                CurrentCommande.Client = new Client()
                {
                    Id = Int32.Parse("" + reader.GetValue(0)),
                    Nom = (string) reader.GetValue(1),
                    Prenom = (string) reader.GetValue(2),
                    Telephone = Int32.Parse("" + reader.GetValue(4)),
                    DateFirst = (string) reader.GetValue(5),
                    Adresse = new Adresse()
                    {
                        Ville = (string) reader.GetValue(3),
                        NumRue = Int32.Parse("" + reader.GetValue(6)),
                        Rue = (string) reader.GetValue(7),
                    },
                };
            }
        }

        public Client AjouterClient(Database databaseObject)
        {
            String nom;
            String prenom;
            String ville;
            double tel;
            String date;
            int numRue;
            String rue;


            Console.WriteLine("Saisissez un nom");
            nom = Console.ReadLine();

            Console.WriteLine("Saisissez un prenom");
            prenom = Console.ReadLine();

            Console.WriteLine("Saisissez une ville");
            ville = Console.ReadLine();

            Console.WriteLine("Saisissez un 06");
            tel = double.Parse(Console.ReadLine());


            Console.WriteLine("Saisissez un numero de rue");
            numRue = int.Parse(Console.ReadLine());

            Console.WriteLine("Saisissez une rue");
            rue = Console.ReadLine();

            date = new DateTime().ToString();

            Console.WriteLine("nom" + nom + "prenom" + prenom + "ville" + ville + "tel" + tel + "date" + date +
                              "numero de la rue" + numRue + "rue" + rue);

            String query =
                "insert into Client ('nom','prenom','ville','telephone','dateFirst','numeroRue','rue') values (@nom,@prenom,@ville,@telephone,@dateFirst,@numeroRue,@rue)";

            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);

            myCommand.Parameters.AddWithValue("@nom", nom);
            myCommand.Parameters.AddWithValue("@prenom", prenom);
            myCommand.Parameters.AddWithValue("@ville", ville);
            myCommand.Parameters.AddWithValue("@telephone", tel);
            myCommand.Parameters.AddWithValue("@dateFirst", date);
            myCommand.Parameters.AddWithValue("@numeroRue", numRue);
            myCommand.Parameters.AddWithValue("@rue", rue);
            var result = myCommand.ExecuteNonQuery();

            databaseObject.myConnection.Close();
            Console.WriteLine("Rows added : {0}", result);
            return new Client()
            {
                Nom = nom, Prenom = prenom, Telephone = (int) tel, DateFirst = date,
                Adresse = new Adresse() {NumRue = numRue, Rue = rue, Ville = ville},
                Id = (int) databaseObject.myConnection.LastInsertRowId
            };
        }

        public void AjouterPizzaCommande(Database databaseObject)
        {
            int id = 0;
            float prix = 0;
            int choixNom;
            int choixTaille;
            string nom = "";
            string taille = "";


            Console.WriteLine("Quelle type de pizza desirez-vous ?\r");
            Console.WriteLine("1- Quatre fromages\r");
            Console.WriteLine("2- Barbecue\r");
            Console.WriteLine("3- Veggie\r");
            choixNom = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quelle taille souhaitez-vous pour votre pizza ?\r");
            Console.WriteLine("1- Petite\r");
            Console.WriteLine("2- Moyenne\r");
            Console.WriteLine("3- Grande\r");
            choixTaille = Convert.ToInt32(Console.ReadLine());


            switch (choixNom)
            {
                case 1:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "quatreFromages";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "quatreFromages";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "quatreFromages";
                            taille = "grande";
                            break;
                    }

                    break;
                case 2:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "barbecue";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "barbecue";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "barbecue";
                            taille = "grande";
                            break;
                    }

                    break;
                case 3:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "veggie";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "veggie";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "veggie";
                            taille = "grande";
                            break;
                    }

                    break;
            }

            string queryId = "select id from Pizzas where nom = \"" + nom + "\" and taille = \"" + taille + "\"";
            SQLiteCommand idCommand = new SQLiteCommand(queryId, databaseObject.myConnection);
            SQLiteDataReader readerId = idCommand.ExecuteReader();
            while (readerId.Read())
            {
                id = readerId.GetInt32(0);
            }

            string queryPrix = "select prix from Pizzas where id = " + id;
            SQLiteCommand prixCommand = new SQLiteCommand(queryPrix, databaseObject.myConnection);
            SQLiteDataReader readerPrix = prixCommand.ExecuteReader();
            while (readerPrix.Read())
            {
                prix = readerPrix.GetInt32(0);
            }

            databaseObject.myConnection.Close();
            Console.WriteLine("id=" + id);

            Type nomPizza = (Type) Enum.Parse(typeof(Type), nom);
            Taille taillePizza = (Taille) Enum.Parse(typeof(Type), taille);

            Pizza pizza = new Pizza() {Id = id, taille = taillePizza, type = nomPizza};

            CurrentCommande.Pizza.Add(pizza);

            Facture facture = new Facture() {Id = 1, Prix = prix};
            facture.AjouterPrixFacture(prix);
        }

        public void GetClients(Database databaseObject)
        {
            String query = "select * from Client ORDER BY nom, prenom";

            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);


            SQLiteDataReader requete = myCommand.ExecuteReader();
            if (!requete.HasRows) Console.WriteLine("Aucun client");
            while (requete.Read())
            {
                Client c = new Client()
                {
                    Id = Int32.Parse("" + requete.GetValue(0)),
                    Nom = (string) requete.GetValue(1),
                    Prenom = (string) requete.GetValue(2),
                    Telephone = Int32.Parse("" + requete.GetValue(4)),
                    DateFirst = (string) requete.GetValue(5),
                    Adresse = new Adresse()
                    {
                        Ville = (string) requete.GetValue(3),
                        NumRue = Int32.Parse("" + requete.GetValue(6)),
                        Rue = (string) requete.GetValue(7),
                    },
                };
                Console.WriteLine(c);
            }
        }

        public void GetClientsByCity(Database databaseObject)
        {
            Console.WriteLine("Veuillez entrer une ville : ");
            string ville = Console.ReadLine();
            String query = "select * from Client where UPPER(ville) LIKE UPPER('" + ville + "')";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            SQLiteDataReader requete = myCommand.ExecuteReader();
            if (!requete.HasRows) Console.WriteLine("Aucun client à " + ville);
            while (requete.Read())
            {
                Client c = new Client()
                {
                    Id = Int32.Parse("" + requete.GetValue(0)),
                    Nom = (string) requete.GetValue(1),
                    Prenom = (string) requete.GetValue(2),
                    Telephone = Int32.Parse("" + requete.GetValue(4)),
                    DateFirst = (string) requete.GetValue(5),
                    Adresse = new Adresse()
                    {
                        Ville = (string) requete.GetValue(3),
                        NumRue = Int32.Parse("" + requete.GetValue(6)),
                        Rue = (string) requete.GetValue(7),
                    },
                };
                Console.WriteLine(c);
            }
        }

        public Adresse trouverAdresse(Database databaseObject)
        {
            Adresse adresse = new Adresse();
            double tel = 0;
            Console.WriteLine("Saisissez le numero de telephone a partir duquel retrouver l'adresse");
            tel = double.Parse(Console.ReadLine());

            String rue = null;
            databaseObject.myConnection.Open();
            String query = "select rue, numeroRue, ville from Client where telephone =  " + tel;
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            SQLiteDataReader rdr = myCommand.ExecuteReader();
            bool rez = rdr.Read();
            Console.WriteLine(rez);
            adresse.Rue = Convert.ToString(rdr["rue"]);
            adresse.NumRue = Convert.ToInt32(rdr["numeroRue"]);
            adresse.Ville = Convert.ToString(rdr["ville"]);
            databaseObject.myConnection.Close();
            return adresse;
        }

        public override string ToString()
        {
            return Id + " : " + Nom + " " + Prenom;
        }

        public void GetAmounts(Database database)
        {
            String query =
                "select  c.id, c.nom , prenom , ville, telephone , dateFirst , numeroRue , rue , SUM(prix) from Client c , Commande co  , Facture f WHERE c.id=co.clientId AND f.id=co.factureId GROUP BY c.id";
            SQLiteCommand myCommand = new SQLiteCommand(query, database.myConnection);
            SQLiteDataReader requete = myCommand.ExecuteReader();
            if (!requete.HasRows) Console.WriteLine("Aucun client");
            while (requete.Read())
            {
                Client c = new Client()
                {
                    Id = Int32.Parse("" + requete.GetValue(0)),
                    Nom = (string) requete.GetValue(1),
                    Prenom = (string) requete.GetValue(2),
                    Telephone = Int32.Parse("" + requete.GetValue(4)),
                    DateFirst = (string) requete.GetValue(5),
                    Adresse = new Adresse()
                    {
                        Ville = (string) requete.GetValue(3),
                        NumRue = Int32.Parse("" + requete.GetValue(6)),
                        Rue = (string) requete.GetValue(7),
                    },
                };
                Console.WriteLine(c + "\r\n           Montant des achats cumulés : " + requete.GetValue(8));
            }
        }

        public void AfficherCommande(Database database)
        {
            Begin:
            Console.WriteLine("Veuillez entrer le numero d'une commande : ");
            string stringIdCommande = Console.ReadLine();
            int idCommand;
            if (!Int32.TryParse(stringIdCommande, out idCommand))
            {
                Console.WriteLine("Veuillez entrer un numero valide ");
                goto Begin;
            }

            String query =
                "SELECT c.id , heure , 'date', cl.nom , cl.prenom , cl.id , p.nom , a.nom " +
                "FROM Commande c, Client cl , Annexe a , Pizza p , AnnexeCommande ac , PizzaCommande pc " +
                "WHERE c.id=ac.commandeId AND a.id=ac.annexeId AND c.id=pc.commandeId AND p.id=pc.pizzaId AND c.id=cl.id AND c.id=" +
                idCommand;
            SQLiteCommand myCommand = new SQLiteCommand(query, database.myConnection);
            SQLiteDataReader requete = myCommand.ExecuteReader();
            if (!requete.HasRows) Console.WriteLine("Aucune commande correspondant à  ce numero " + idCommand);
            Commande c = null;
            while (requete.Read())
            {
                if (c is null)
                {
                    c = new Commande()
                    {
                        Id = Int32.Parse("" + requete.GetValue(0)),
                        DateHeure = (string) requete.GetValue(1) + " " + (string) requete.GetValue(2),
                        Client = new Client()
                        {
                            Id = Int32.Parse("" + requete.GetValue(5)),
                            Nom = (string) requete.GetValue(3),
                            Prenom = (string) requete.GetValue(4),
                        },
                        Pizza = new List<Pizza>(),
                        Annexe = new List<Annexe>(),
                    };
                }

                c.Pizza.Add(new Pizza() {Nom = (string) requete.GetValue(6)});
                c.Annexe.Add(new Annexe() {Nom = (string) requete.GetValue(7)});
            }

            Console.WriteLine(c);
        }

        public void AjouterAnnexe(Database database)
        {
            throw new NotImplementedException();
        }
    }
}