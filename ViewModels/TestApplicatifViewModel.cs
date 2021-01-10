using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using TestApplicatif.Base;
using TestApplicatif.Models;

namespace TestApplicatif.ViewModels
{
    class TestApplicatifViewModel : ModelBase
    {
        #region Variables

        private TestApplicatif.Views.TestApplicatif _view;
        private Account _account;
        private Entry _entry;
        private Ledger _ledger;

        #endregion

        #region Propriétés

        public TestApplicatif.Views.TestApplicatif View
        {
            get { return _view; }
            set
            {
                if (_view == value) return;
                _view = value;
                OnPropertyChanged();
            }
        }

        public Account Account
        {
            get { return _account; }
            set
            {
                if (_account == value) return;
                _account = value;
                OnPropertyChanged();
            }
        }

        public Entry Entry
        {
            get { return _entry; }
            set
            {
                if (_entry == value) return;
                _entry = value;
                OnPropertyChanged();
            }
        }

        public Ledger Ledger
        {
            get { return _ledger; }
            set
            {
                if (_ledger == value) return;
                _ledger = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeurs

        public TestApplicatifViewModel()
        {
            View = new Views.TestApplicatif();
        }

        #endregion

        #region Méthodes publiques
         
        // Dispatcheur de fonctions
        public void Function(string choice)
        {
            int value = Int32.Parse(choice);

            switch (value)
            {
                case 1:
                    Linq();
                    break;
                case 2:
                    Lambda();
                    break;
                case 3:
                    Sql();
                    break;
                case 4:
                    Fibo();
                    break;
            }
        }

        #endregion

        #region Méthodes privées

        // Méthode 1 : Linq to SQL
        private void Linq()
        {
            using (ApplicationDbContext context = new ApplicationDbContextFactory().Create())
            {
                //ApplicationDbContext context = new ApplicationDbContext(new SQLiteConnection() { ConnectionString = "Data Source=BDD/BaseTest.db" });

                var query = from acc in context.Accounts
                            join led in context.Ledger on acc.Id equals led.AccountId
                            group new { led.Amount } by new { acc.Name, led.Amount } into g
                            select new { val1 = g.Key.Name, val2 = Math.Abs(g.Key.Amount) };

                if (query != null)
                {
                    Console.WriteLine("\n Linq to Sql :\n");
                    foreach (var item in query)
                    {
                        Console.WriteLine(string.Format("{0} {1}\n", item.val1, item.val2));
                    }
                }
            }

            View.Menu(false);
        }

        // Méthode 2 : Expression Lambda
        private void Lambda()
        {
            using (ApplicationDbContext context = new ApplicationDbContextFactory().Create())
            {
                //ApplicationDbContext context = new ApplicationDbContext(new SQLiteConnection() { ConnectionString = "Data Source=BDD/BaseTest.db" });

                var query = context.Ledger
                            .Join(context.Accounts, led => led.AccountId, acc => acc.Id, (led, acc) => new { led, acc })
                            .GroupBy(grp => new { grp.acc.Name, grp.led.EntryId })
                            .Select(n => new
                            {
                                Name = n.Key.Name,
                                Entries = n.Key.EntryId
                            });

                if (query != null)
                {
                    Console.WriteLine("\n Lambda :\n");
                    foreach (var item in query)
                    {
                        Console.WriteLine(string.Format("Compte : {0}, Comptes impactés : {1}\n", item.Name, item.Entries));
                    }
                }
            }

            View.Menu(false);
        }

        // Méthode 3 : SQL
        private void Sql()
        {
            using (var connection = new SQLiteConnection(@"Data Source=BDD/BaseTest.db"))
            {
                // Méthode 1 (pour comparatif perf.) :
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    //command.CommandText = "SELECT Name, SUM(CASE WHEN Amount > 0 THEN Amount || ' => KO.U' WHEN Amount < 0 THEN Amount || ' => KO.D' WHEN Amount = 0 THEN Amount || ' => OK' END) AS Total FROM Account, Ledger WHERE Account.Id = Ledger.AccountId GROUP BY Account.Id";
                    command.CommandText = "SELECT Name, SUM(Amount) as Total, (CASE WHEN SUM(Amount) > 0 THEN ' => KO.U' WHEN  SUM(Amount) < 0 THEN ' => KO.D' ELSE ' => OK' END) AS Mention FROM Account, Ledger WHERE Account.Id = Ledger.AccountId GROUP BY Account.Id";

                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nSqlite :\n");
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            var total = reader["Total"].ToString();
                            var mention = reader["Mention"].ToString();
                            Console.WriteLine(string.Format("{0} {1} {2}", name, total, mention));
                        }
                    }
                    connection.Close();
                }

                // Méthode 2 (pour comparatif perf.) :
                using (var command2 = connection.CreateCommand())
                {
                    connection.Open();
                    command2.CommandText = "SELECT Name, SUM(Amount) AS Total FROM Account, Ledger where Account.Id = Ledger.AccountId group by Account.Id";

                    using (var reader = command2.ExecuteReader())
                    {
                        Console.WriteLine("\nSqlite :\n");
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            var total = reader["Total"].ToString();
                            var mention = string.Empty;
                            if (double.Parse(total) > 0) mention = "KO.U";
                            else if (double.Parse(total) < 0) mention = "KO.D";
                            else mention = "OK";
                            Console.WriteLine(string.Format("{0} {1} => {2}", name, total, mention));
                        }
                    }
                    connection.Close();
                }
            }
            View.Menu(false);
        }

        // Méthode 4 : Suite de Fibonacci avec paramètre d'entrée
        private void Fibo()
        {
            Console.WriteLine("\nEntrez un nombre :\n");
            var saisie = Console.ReadLine();
            int nombre = 0;
            bool error;

            do
            {
                try
                {
                    error = false;
                    nombre = int.Parse(saisie);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nSaisie incorrecte !\n");
                    saisie = Console.ReadLine();
                    error = true;
                }
            } while (error);

            Console.WriteLine(string.Format("\nSuite de Fibonacci sur une série de {0} :\n", nombre));
            for (int i = 0; i <= nombre; i++)
            {
                Console.Write("{0} : {1}\n", i, FindFibonacci(i));
            }

            View.Menu(false);
        }

        private static int FindFibonacci(int n)
        {
            int p = 0;
            int q = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = p;
                p = q;
                q = temp + q;
            }
            return p;
        }

        #endregion

    }
}
