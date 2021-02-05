using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatif.ViewModels;

namespace TestApplicatifTests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestLinqFunction()
        {
            // Arrange
            int choice = 1;
            TestApplicatifViewModel TestAppliVM = new TestApplicatifViewModel();

            // Act
            TestAppliVM.IsTest = true;
            TestAppliVM.Function(choice.ToString());

            // Assert
            Assert.IsTrue(TestAppliVM.IsTestOk == true, "Erreur d'éxecution de la requête Linq");
        }

        [TestMethod]
        public void TestLambdaFunction()
        {
            // Arrange
            int choice = 2;
            TestApplicatifViewModel TestAppliVM = new TestApplicatifViewModel();

            // Act
            TestAppliVM.IsTest = true;
            TestAppliVM.Function(choice.ToString());

            // Assert
            Assert.IsTrue(TestAppliVM.IsTestOk == true, "Erreur d'éxecution de la requête Lambda");
        }

        [TestMethod]
        public void TestSqlFunction()
        {
            // Arrange
            int choice = 3;
            TestApplicatifViewModel TestAppliVM = new TestApplicatifViewModel();

            // Act
            TestAppliVM.IsTest = true;
            TestAppliVM.Function(choice.ToString());

            // Assert
            Assert.IsTrue(TestAppliVM.IsTestOk == true, "Erreur d'éxecution de la requête Sql");
        }

        [TestMethod]
        public void TestFiboFunction()
        {
            // Arrange
            int choice = 4;
            TestApplicatifViewModel TestAppliVM = new TestApplicatifViewModel();

            // Act
            TestAppliVM.IsTest = true;
            TestAppliVM.Function(choice.ToString());

            // Assert
            Assert.IsTrue(TestAppliVM.IsTestOk == true, "Erreur d'éxecution de la requête Fibo");
        }

        [TestMethod]
        public void TestBadEntry()
        {
            // Arrange
            int choice = 5;
            TestApplicatifViewModel TestAppliVM = new TestApplicatifViewModel();

            // Act
            TestAppliVM.IsTest = true;
            TestAppliVM.Function(choice.ToString());

            // Assert
            Assert.IsTrue(TestAppliVM.IsTestOk != true, "Mauvais choix de Function mal géré");
        }
    }
}
