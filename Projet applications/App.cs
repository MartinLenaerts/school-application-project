using System;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Data.SQLite;
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

            Begin:
            WelcomeMessage();
            int commisId = Console.Read();
            SQLiteDataReader reader = Database.Select("SELECT * FROM Commis WHERE id=" + commisId);

            if (!reader.HasRows)
            {
                Console.WriteLine("Aucun commis ne correspond à ce numero");
                goto Begin;
            }

            reader.Read();

            CurrentCommis = new Commis()
            {
                Id = reader.GetInt32(0),
                Nom = reader.GetString(0),
                Prenom = reader.GetString(0)
            };

            try
            {
                int choice = Console.Read();
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
            Console.WriteLine("Bienvenue ! ");
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : pour gerer les clients");
            Console.WriteLine("2 : pour gerer les commandes");
            Console.WriteLine("3 : pour afficher les statistiques");
        }

        public void ClientManagement()
        {
            Console.WriteLine("Entrez : ");
            Console.WriteLine("1 : pour afficher les clients par ordre alphabetiques");
            Console.WriteLine("2 : pour afficher les clients par ordre ville");
            Console.WriteLine("3 : pour afficher montants des achats cumulés");
            Begin:
            try
            {
                int choice = Console.Read();
                switch (choice)
                {
                    case 1:
                        CurrentCommis.GetClients(Database);
                        break;
                    case 2:
                        CurrentCommis.GetClientsByCity(Database);
                        break;
                    case 3:
                        //CurrentCommis.GetAmounts(Database);
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