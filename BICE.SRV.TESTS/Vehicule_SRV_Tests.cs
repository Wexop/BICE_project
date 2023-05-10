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
    public class Vehicule_SRV_Tests
    {
        [Fact]
        public void Vehicule_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<string>())).Returns(new Vehicule_DAL("AZERTY", "Kangoo", 1111, true));

            var srv = new Vehicule_SRV(mock.Object);

            var result = srv.GetById("AZERTY");

            Assert.NotNull(result);
            Assert.IsType<Vehicule_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Vehicule_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Vehicule_DAL>()
            {
                new Vehicule_DAL("Test", "Kangoo", 1111, true),
                new Vehicule_DAL("AZERTY", "C4", 1451, true),
            });

            var srv = new Vehicule_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Vehicule_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void Vehicule_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Vehicule_DAL>()));
            var srv = new Vehicule_SRV(mock.Object);

            //ACT
            srv.Modifier(new Vehicule_DTO()
            {
                Immatriculation = "AZERTY",
                Nom = "Test",
                Numero = 1234,
                Utilisable= true,
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<Vehicule_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Vehicule_SRV_Ajouter()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Vehicule_DAL>()));
            var srv = new Vehicule_SRV(mock.Object);

            //ACT
            srv.Ajouter(new Vehicule_DTO()
            {
                Immatriculation = "AZERTY",
                Nom = "Test",
                Numero = 1234,
                Utilisable = true,
            });

            //ASSERT
            mock.Verify(depot => depot.Insert(It.IsAny<Vehicule_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Vehicule_SRV_Supprimer()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<string>()));
            mock.Setup(d => d.GetById(It.IsAny<string>())).Returns(new Vehicule_DAL("AZERTY", "Kangoo", 1111, true));

            var srv = new Vehicule_SRV(mock.Object);

            //ACT
            srv.Supprimer("Test");

            //ASSERT
            mock.Verify(depot => depot.Delete(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
