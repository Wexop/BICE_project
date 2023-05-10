using BICE.BLL;
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
    public class VehiculeIntervention_SRV_Tests
    {
        [Fact]
        public void VehiculeIntervention_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<VehiculeIntervention_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new VehiculeIntervention_DAL(1, 2, "AZERTY"));

            var srv = new VehiculeIntervention_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<VehiculeIntervention_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact]
        public void VehiculeIntervention_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<VehiculeIntervention_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<VehiculeIntervention_DAL>()
            {
                new VehiculeIntervention_DAL(1, 2, "AZERTY"),
                new VehiculeIntervention_DAL(1, 5, "ZERTG"),
                new VehiculeIntervention_DAL(5, 1, "GHZERT"),
            });

            var srv = new VehiculeIntervention_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<VehiculeIntervention_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void VehiculeIntervention_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<VehiculeIntervention_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<VehiculeIntervention_DAL>()));
            var srv = new VehiculeIntervention_SRV(mock.Object);

            //ACT
            srv.Modifier(new VehiculeIntervention_DTO()
            {
                idIntervention = 1,
                immatriculationVehicule = "AZERT",
                IdVehiculeIntervention= 1,
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<VehiculeIntervention_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void VehiculeIntervention_SRV_Ajouter()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<VehiculeIntervention_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<VehiculeIntervention_DAL>()));
            var srv = new VehiculeIntervention_SRV(mock.Object);

            //ACT
            srv.Ajouter(new VehiculeIntervention_DTO()
            {
                idIntervention = 1,
                immatriculationVehicule = "AZERT",
                IdVehiculeIntervention = 1,
            });

            //ASSERT
            mock.Verify(depot => depot.Insert(It.IsAny<VehiculeIntervention_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void VehiculeIntervention_SRV_Supprimer()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<VehiculeIntervention_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<int>()));
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new VehiculeIntervention_DAL(1, 2, "AZERTY"));

            var srv = new VehiculeIntervention_SRV(mock.Object);

            //ACT
            srv.Supprimer(1);

            //ASSERT
            mock.Verify(depot => depot.Delete(It.IsAny<int>()), Times.AtLeastOnce);
        }


    }
}
