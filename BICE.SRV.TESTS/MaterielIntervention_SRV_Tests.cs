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
    public class MaterielIntervention_SRV_Tests
    {
        [Fact]
        public void MaterielIntervention_SRV_GetById()
        {
            var mock = new Mock<IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>(), It.IsAny<string>())).Returns(new MaterielIntervention_DAL(1, "TEST"));

            var srv = new MaterielIntervention_SRV(mock.Object);

            var result = srv.GetById(1, "Test");

            Assert.NotNull(result);
            Assert.IsType<MaterielIntervention_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public void MaterielIntervention_SRV_GetAll()
        {
            var mock = new Mock<IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<MaterielIntervention_DAL>()
            {
                new MaterielIntervention_DAL(1, "TEST"),
                new MaterielIntervention_DAL(2, "DFG"),
            });

            var srv = new MaterielIntervention_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<MaterielIntervention_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void MaterielIntervention_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<MaterielIntervention_DAL>()));
            var srv = new MaterielIntervention_SRV(mock.Object);

            //ACT
            srv.Modifier(new MaterielIntervention_DTO()
            {
                IdVehiculeIntervention = 1,
                CodeBarreMateriel = "AZER"
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<MaterielIntervention_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void MaterielIntervention_SRV_Ajouter()
        {
            //arrange
            var mock = new Mock<IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<MaterielIntervention_DAL>()));
            var srv = new MaterielIntervention_SRV(mock.Object);

            //ACT
            srv.Ajouter(new MaterielIntervention_DTO()
            {
                IdVehiculeIntervention = 1,
                CodeBarreMateriel = "AZER"
            });

            //ASSERT
            mock.Verify(depot => depot.Insert(It.IsAny<MaterielIntervention_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void MaterielIntervention_SRV_Supprimer()
        {
            //arrange
            var mock = new Mock<IMaterielIntervention_Depot_DAL<MaterielIntervention_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<int>()));
            mock.Setup(d => d.GetById(It.IsAny<int>(), It.IsAny<string>())).Returns(new MaterielIntervention_DAL(1, "TEST"));

            var srv = new MaterielIntervention_SRV(mock.Object);

            //ACT
            srv.Supprimer(1, "test");

            //ASSERT
            mock.Verify(depot => depot.Delete(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce);
        }

    }
}
