using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicatif.ViewModels;

namespace TestApplicatif.Views
{
    public class TestApplicatif
    {
        #region Constructeurs

        public TestApplicatif()
        {
        }

        #endregion

        #region Affichage des menus

        static void Main(string[] args)
        {
            TestApplicatif ta = new TestApplicatif();
            ta.Menu(true);
        }

        // Menu d'acceuil
        public void Menu(bool firstlaunch)
        {
            if (firstlaunch) Console.WriteLine("Voulez-vous effectuer des calculs ou quitter l’application ? \nC : Calculs \nQ : Quitter\n");
            else Console.WriteLine("\nVoulez-vous effectuer des calculs ou quitter l’application ? \nC : Calculs \nQ : Quitter\n");

            // Si choix autre que C ou Q = message d'erreur
            var answer = string.Format("{0}", Console.ReadLine().ToUpper());
            while (answer != "C" || answer != "Q")
            {
                if (answer == "C")
                {
                    SousMenu();
                }
                else if (answer == "Q")
                {
                    Console.WriteLine("\nMerci et à bientôt.");

                    Task.Delay(4000).ContinueWith(_ =>
                    {
                        Environment.Exit(110);
                    });
                }
                else Console.WriteLine("\nSaisie incorrecte !\n");

                answer = string.Format("{0}", Console.ReadLine().ToUpper());
            }
        }

        // Sous menu des calculs
        public void SousMenu()
        {
            TestApplicatifViewModel vm = new TestApplicatifViewModel();
            Console.WriteLine("\n1 : Linq \n2 : Lambda\n3 : Sql\n4 : Fibo\n5 : Retour\n");

            // Si choix autre que 1, 2, 3, 4 ou 5 = message d'erreur
            var choice = string.Format("{0}", Console.ReadLine());
            while (choice != "1" || choice != "2" || choice != "3" || choice != "4" || choice != "5")
            {
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    vm.Function(choice);
                }
                else if (choice == "5") Menu(false);
                else Console.WriteLine("\nSaisie incorrecte !\n");

                choice = string.Format("{0}", Console.ReadLine());
            }
        }

        #endregion
    }
}
