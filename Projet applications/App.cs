using System;
using System.Collections.Generic;
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
        public bool Running { get; set; }
        public Database Database { get; set; }

        public bool hasSeeding { get; set; }

        public void Start()
        {
            if (!hasSeeding)
            {
                Database.Seed();
                hasSeeding = true;
            }


            if (CurrentCommis == null)
            {
                Begin:
                WelcomeMessage();
                string stringCommisId = Console.ReadLine();
                int commisId;
                if (!Int32.TryParse(stringCommisId, out commisId))
                {
                    CustomConsole.PrintError("Veuillez entrer un id valide");
                    goto Begin;
                }

                SQLiteDataReader reader =
                    Database.Select("SELECT * FROM Employee WHERE type='commis' AND  id=" + commisId.ToString());
                if (!reader.HasRows)
                {
                    CustomConsole.PrintError("Aucun commis ne correspond à ce numero");
                    goto Begin;
                }

                reader.Read();

                CurrentCommis = new Commis()
                {
                    Id = Int32.Parse("" + reader.GetValue(0)),
                    Nom = (string) reader.GetValue(1),
                    Prenom = (string) reader.GetValue(2)
                };
            }

            Menu:
            MenuMessage();
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    CustomConsole.PrintError("Veuillez entrer un numero valide");
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
                    case 9:
                        Running = false;
                        break;
                    default:
                        CustomConsole.PrintError("Veuillez choisir un nombre valide");
                        goto Menu;
                }
            }
            catch (Exception e)
            {
                CustomConsole.PrintError(e.Message);
                goto Menu;
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
            CustomConsole.PrintChoice(1, "pour gerer les clients");
            CustomConsole.PrintChoice(2, "pour gerer les commandes");
            CustomConsole.PrintChoice(3, "pour afficher les statistiques");
            CustomConsole.PrintChoice(9, "pour quitter");
        }

        public void ClientManagement()
        {
            Begin:
            Console.WriteLine("Entrez : ");
            CustomConsole.PrintChoice(1, "pour afficher les clients par ordre alphabetiques");
            CustomConsole.PrintChoice(2, "pour afficher les clients d'une ville");
            CustomConsole.PrintChoice(3, "pour afficher montants des achats cumulés");
            CustomConsole.PrintChoice(9, "pour quitter");
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    CustomConsole.PrintError("Veuillez entrer un numero valide");
                    goto Begin;
                }

                switch (choice)
                {
                    case 1:
                        CurrentCommis.GetClients(Database);
                        goto Begin;
                    case 2:
                        CurrentCommis.GetClientsByCity(Database);
                        goto Begin;
                    case 3:
                        CurrentCommis.GetAmounts(Database);
                        goto Begin;
                    case 9:
                        break;
                    default:
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                CustomConsole.PrintError(e.Message);
                goto Begin;
            }
        }

        public void CommandeManagement()
        {
            Begin:
            Console.WriteLine("Entrez : ");
            CustomConsole.PrintChoice(1, "creer une nouvelle commande");
            CustomConsole.PrintChoice(2, "afficher une commande");
            CustomConsole.PrintChoice(3, "modifier une commande");
            CustomConsole.PrintChoice(9, "pour quitter");
            try
            {
                string stringChoice = Console.ReadLine();
                int choice;
                if (!Int32.TryParse(stringChoice, out choice))
                {
                    CustomConsole.PrintError("Veuillez entrer un numero valide");
                    goto Begin;
                }

                switch (choice)
                {
                    case 1:
                        CurrentCommis.CreerCommande(Database);
                        goto Begin;
                    case 2:
                        CurrentCommis.AfficherCommande(Database);
                        goto Begin;
                    case 3:
                        SetCommand();
                        break;
                    case 9:
                        break;
                    default:
                        goto Begin;
                }
            }
            catch (Exception e)
            {
                CustomConsole.PrintError(e.Message);
                goto Begin;
            }
        }

        public void SetCommand()
        {
            Begin:
            Console.Write("Entrez le numero de la commande : ");
            string stringIdCommande = Console.ReadLine();
            int idCommande;
            if (!Int32.TryParse(stringIdCommande, out idCommande))
            {
                CustomConsole.PrintError("Veuillez entrer un numero valide");
                goto Begin;
            }

            string query = "SELECT * FROM Commande WHERE id=" + idCommande;
            SQLiteCommand myCommand = new SQLiteCommand(query, Database.myConnection);
            SQLiteDataReader requete = myCommand.ExecuteReader();
            if (!requete.HasRows)
            {
                CustomConsole.PrintError("Aucune commande avec ce numero");
                goto Begin;
            }

            requete.Read();
            CurrentCommis.CurrentCommande = new Commande() {Id = Int32.Parse("" + requete.GetValue(0))};

            BeginSet:
            Console.WriteLine("Entrez : ");
            CustomConsole.PrintChoice(1, "Ajouter des pizzas");
            CustomConsole.PrintChoice(2, "Ajouter des Annexes");
            CustomConsole.PrintChoice(9, "Pour quitter");

            string stringChoice = Console.ReadLine();
            int choice;
            if (!Int32.TryParse(stringChoice, out choice))
            {
                CustomConsole.PrintError("Veuillez entrer un numero valide");
                goto BeginSet;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        CurrentCommis.AjouterPizzaCommande(Database);
                        goto BeginSet;
                    case 2:
                        CurrentCommis.AjouterAnnexe(Database);
                        goto BeginSet;
                    case 9:
                        break;
                    default:
                        goto BeginSet;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                goto BeginSet;
            }
        }

        public void StatistiquesManagement()
        {
            Console.WriteLine("Entrez : ");
            CustomConsole.PrintChoice(1, "Afficher par commis, le nombre de commandes gerees");
            CustomConsole.PrintChoice(2, "Afficher par livreur le nombre de livraisons effectuees ");
            CustomConsole.PrintChoice(3, "Afficher les commandes selon une periode de temps ");
            CustomConsole.PrintChoice(2, "Afficher la moyenne des prix des commandes");
            CustomConsole.PrintChoice(3, "Afficher la moyenne des comptes clients");
        }
    }
}