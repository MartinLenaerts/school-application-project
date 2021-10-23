using System;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace Projet_applications
{
    public class App
    {
        public Commis CurrentCommis { get; set; }

        public Commis CurrentCommande { get; set; }

        public Database Database { get; set; }

        public void Start()
        {
            Database.Open();
            Database.Seed();

            Begin:
            WelcomeMessage();
            string stringCommisId = Console.ReadLine();
            int commisId;
            if (!Int32.TryParse(stringCommisId, out commisId))
            {
                Console.WriteLine("Veuillez entrer un id valide");
                goto Begin;
            }

            SQLiteDataReader reader =
                Database.Select("SELECT * FROM Employee WHERE type='commis' AND  id=" + commisId.ToString());
            if (!reader.HasRows)
            {
                Console.WriteLine("Aucun commis ne correspond à ce numero");
                goto Begin;
            }

            reader.Read();

            CurrentCommis = new Commis()
            {
                Id = Int32.Parse("" + reader.GetValue(0)),
                Nom = (string) reader.GetValue(1),
                Prenom = (string) reader.GetValue(2)
            };

            Menu:
            MenuMessage();
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    Console.WriteLine("Veuillez entrer un id valide");
                    goto Menu;
                }

                switch (choice)
                {
                    case 1:
                        ClientManagement();
                        break;
                    case 2:
                        CommandeManagement();
                        break;
                    case 3:
                        StatistiquesManagement();
                        break;
                    default:
                        Console.WriteLine("Veuillez choisir un nombre valide");
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Begin;
            }

            Database.Close();
        }


        public void WelcomeMessage()
        {
            Console.WriteLine("Bienvenue ! ");
            Console.WriteLine("Veuillez entrer votre identifiant de commis : ");
        }

        public void MenuMessage()
        {
            Console.WriteLine("Bonjour " + CurrentCommis.Nom + " " + CurrentCommis.Prenom);
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : pour gerer les clients");
            Console.WriteLine("2 : pour gerer les commandes");
            Console.WriteLine("3 : pour afficher les statistiques");
        }

        public void ClientManagement()
        {
            Begin:
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : pour afficher les clients par ordre alphabetiques");
            Console.WriteLine("2 : pour afficher les clients d'une ville");
            Console.WriteLine("3 : pour afficher montants des achats cumulés");
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    Console.WriteLine("Veuillez entrer un numero valide");
                    goto Begin;
                }

                switch (choice)
                {
                    case 1:
                        CurrentCommis.GetClients(Database);
                        break;
                    case 2:
                        CurrentCommis.GetClientsByCity(Database);
                        break;
                    case 3:
                        CurrentCommis.GetAmounts(Database);
                        break;
                    default:
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Begin;
            }
        }

        public void CommandeManagement()
        {
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : creer une nouvelle commande");
            Console.WriteLine("2 : afficher une commande");
            Console.WriteLine("3 : modifier une commande");
            Begin:
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    Console.WriteLine("Veuillez entrer un numero valide");
                    goto Begin;
                }

                switch (choice)
                {
                    case 1:
                        CurrentCommis.CreerCommande(Database);
                        break;
                    case 2:
                        CurrentCommis.AfficherCommande(Database);
                        break;
                    case 3:
                        SetCommand();
                        break;
                    default:
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                goto Begin;
            }
        }

        private void SetCommand()
        {
            Begin:
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : Ajouter des pizzas");
            Console.WriteLine("2 : Ajouter des Annexes");

            string stringChoice = Console.ReadLine();
            int choice;
            if (!Int32.TryParse(stringChoice, out choice))
            {
                Console.WriteLine("Veuillez entrer un numero valide");
                goto Begin;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        CurrentCommis.AjouterPizzaCommande(Database);
                        break;
                    case 2:
                        CurrentCommis.AjouterAnnexe(Database);
                        break;
                    default:
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                goto Begin;
            }
        }

        public void StatistiquesManagement()
        {
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : Afficher par commis, le nombre de commandes gerees");
            Console.WriteLine("2 : Afficher par livreur le nombre de livraisons effectuees ");
            Console.WriteLine("3 : Afficher les commandes selon une periode de temps ");
            Console.WriteLine("2 : Afficher la moyenne des prix des commandes");
            Console.WriteLine("3 : Afficher la moyenne des comptes clients");
        }
    }
}