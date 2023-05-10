using BICE.DAL;
using BICE.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV.TESTS
{
    public class Materiel_SRV_Tests
    {
        [Fact]
        public void Materiel_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<string>())).Returns(new Materiel_DAL("AZERTY", "Joe", 1, 12, 15, DateTime.Now, DateTime.Now, DateTime.Now, true, "YTREZA"));

            var srv = new Materiel_SRV(mock.Object);

            var result = srv.GetById("test");

            Assert.NotNull(result);
            Assert.IsType<Materiel_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Materiel_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Materiel_DAL>()
            {
                new Materiel_DAL("AZERTY", "Joe", 1, 12, 15, DateTime.Now, DateTime.Now, DateTime.Now, true, "YTREZA"),
                new Materiel_DAL("RTYU", "Ilyas", 1, 4, 15, DateTime.Now, DateTime.Now, DateTime.Now, false, "DFGH")
            });

            var srv = new Materiel_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Materiel_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void Materiel_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Materiel_DAL>()));
            var srv = new Materiel_SRV(mock.Object);

            //ACT
            srv.Modifier(new Materiel_DTO()
            {
                CodeBarre = "test",
                Nom= "Joe",
                Nb_utilisation = 1,
                Nb_utilisation_max= 1,
                Date_controle = DateTime.Now,
                Date_peremption = DateTime.Now,
                Date_prochain_controle = DateTime.Now,
                Categorie_ID= 1,
                Stock = true,
                Vehicule_ID = "SuperLaVoiture"
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Materiel_SRV_Ajouter()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Materiel_DAL>()));
            var srv = new Materiel_SRV(mock.Object);

            //ACT
            srv.Ajouter(new Materiel_DTO()
            {
                CodeBarre = "test",
                Nom = "Joe",
                Nb_utilisation = 1,
                Nb_utilisation_max = 1,
                Date_controle = DateTime.Now,
                Date_peremption = DateTime.Now,
                Date_prochain_controle = DateTime.Now,
                Categorie_ID = 1,
                Stock = true,
                Vehicule_ID = "SuperLaVoiture"
            });

            //ASSERT
            mock.Verify(depot => depot.Insert(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Materiel_SRV_ModifierRetourIntervention()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Materiel_DAL>()));
            var srv = new Materiel_SRV(mock.Object);

            //ACT
            srv.ModifierRetourInterventionUtiliser(new Materiel_DTO()
            {
                CodeBarre = "test",
                Nom = "Joe",
                Nb_utilisation = 1,
                Nb_utilisation_max = 1,
                Date_controle = DateTime.Now,
                Date_peremption = DateTime.Now,
                Date_prochain_controle = DateTime.Now,
                Categorie_ID = 1,
                Stock = true,
                Vehicule_ID = "SuperLaVoiture"
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Materiel_SRV_Supprimer()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<string>()));
            mock.Setup(d => d.GetById(It.IsAny<string>())).Returns(new Materiel_DAL("AZERTY", "Joe", 1, 12, 15, DateTime.Now, DateTime.Now, DateTime.Now, true, "YTREZA"));

            var srv = new Materiel_SRV(mock.Object);

            //ACT
            srv.Supprimer("Test");

            //ASSERT
            mock.Verify(depot => depot.Delete(It.IsAny<string>()), Times.AtLeastOnce);
        }


    }
}
