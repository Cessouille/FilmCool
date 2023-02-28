using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmCool.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmCool.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using FilmCool.Models.DataManager;
using FilmCool.Models.Repository;

namespace FilmCool.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private readonly FilmRatingsDBContext _context;
        private readonly UtilisateursController _controller;
        private IDataRepository<Utilisateur> _dataRepository;
        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            _context = new FilmRatingsDBContext(builder.Options);
            _dataRepository = new UtilisateurManager(_context);
            //_controller = new UtilisateursController(_dataRepository);

        }

        [TestMethod()]
        public void GetUtilisateursTest_Ok()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            // Act
            var result = _context.Utilisateurs.Where(s => s.UtilisateurId <= 3).ToList();
            /*lesUtilisateurs.Add(new Utilisateur(1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023,02,22), new List<Notation>()));
            lesUtilisateurs.Add(new Utilisateur(2, "Gwendolin", "Dominguez", "0724970555", "gdominguez0@washingtonpost.com", "Toto12345678!", "Chemin de gom", "73420", "Voglans", "France", (float)45.622154, (float)5.8853216, new DateTime(2023, 02, 22), new List<Notation>()));
            lesUtilisateurs.Add(new Utilisateur(3, "Randolph", "Richings", "0630271158", "rrichings1@naver.com", "Toto12345678!", "Route des charmottes d'en bas", "74890", "Bons-en-Chablais", "France", (float)46.25732, (float)6.367676, new DateTime(2023, 02, 22), new List<Notation>()));*/
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Utilisateur>), "Pas un IEnumerable");
            CollectionAssert.AreEqual(lesUtilisateurs, result);
        }

        [TestMethod()]
        public void GetUtilisateurById_Ok()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            // Act
            var result = _context.Utilisateurs.Where(c => c.UtilisateurId == 1).FirstOrDefault();
            /*Utilisateur unUtilisateur = new Utilisateur(1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 22), new List<Notation>());*/
            // Assert
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            /*Assert.AreEqual(unUtilisateur, result);*/
        }

        [TestMethod()]
        public void GetUtilisateurById_NonOk()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            // Act
            var result = _context.Utilisateurs.Where(c => c.UtilisateurId == 2).FirstOrDefault();
            /*Utilisateur unUtilisateur = new Utilisateur(1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 22), new List<Notation>());*/
            // Assert
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            /*Assert.AreNotEqual(unUtilisateur, result);*/
        }

        [TestMethod()]
        public void GetUtilisateurByEmail_Ok()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            // Act
            var result = _context.Utilisateurs.Where(c => c.Mail == "clilleymd@last.fm").FirstOrDefault();
            /*Utilisateur unUtilisateur = new Utilisateur(1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 22), new List<Notation>());*/
            // Assert
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            /*Assert.AreEqual(unUtilisateur, result);*/
        }

        [TestMethod()]
        public void GetUtilisateurByEmail_NonOk()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            // Act
            var result = _context.Utilisateurs.Where(c => c.Mail == "gdominguez0@washingtonpost.com").FirstOrDefault();
            /*Utilisateur unUtilisateur = new Utilisateur(1, "Calida", "Lilley", "0653930778", "clilleymd@last.fm", "Toto12345678!", "Impasse des bergeronnettes", "74200", "Allinges", "France", (float)46.344795, (float)6.4885845, new DateTime(2023, 02, 22), new List<Notation>());*/
            // Assert
            Assert.IsInstanceOfType(result, typeof(Utilisateur), "Pas un Utilisateur");
            /*Assert.AreNotEqual(unUtilisateur, result);*/
        }

        [TestMethod]
        public void PostUtilisateur_CreationOK()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            FilmRatingsDBContext _context = new FilmRatingsDBContext(builder.Options);
            UtilisateursController controller = new UtilisateursController(_context);
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = controller.PostUtilisateur(userAtester).Result; // .Result pour appeler la méthode async de manière synchrone, afin d'attendre l’ajout
            // Assert
            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }
    }
}