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
    public class Intervention_SRV_Tests
    {
        [Fact]
        public void Intervention_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Intervention_DAL(1, DateTime.Now));

            var srv = new Intervention_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<Intervention_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Intervention_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Intervention_DAL>()
            {
                new Intervention_DAL(1, DateTime.Now),
                new Intervention_DAL(4, DateTime.Now),
                new Intervention_DAL(2, DateTime.Now),
            });

            var srv = new Intervention_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Intervention_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void Intervention_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Intervention_DAL>()));
            var srv = new Intervention_SRV(mock.Object);

            //ACT
            srv.Modifier(new Intervention_DTO()
            {
                Id_intervention= 1,
                Date_intervention= DateTime.Now,
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<Intervention_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Intervention_SRV_Ajouter()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Intervention_DAL>()));
            var srv = new Intervention_SRV(mock.Object);

            //ACT
            srv.Ajouter(new Intervention_DTO()
            {
                Id_intervention = 1,
                Date_intervention = DateTime.Now,
            });

            //ASSERT
            mock.Verify(depot => depot.Insert(It.IsAny<Intervention_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void intervention_SRV_Supprimer()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<int>()));
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Intervention_DAL(1, DateTime.Now));

            var srv = new Intervention_SRV(mock.Object);

            //ACT
            srv.Supprimer(1);

            //ASSERT
            mock.Verify(depot => depot.Delete(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}
