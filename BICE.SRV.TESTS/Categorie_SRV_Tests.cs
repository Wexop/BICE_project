using BICE.DTO;
using BICE.SRV;
using BICE.DAL;
using Moq;

namespace BICE.SRV.TESTS
{
    public class Categorie_SRV_Tests
    {
        [Fact]
        public void Categorie_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Categorie_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Categorie_DAL(1, "Test"));

            var srv = new Categorie_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<Categorie_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Categorie_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Categorie_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Categorie_DAL>()
            {
                new Categorie_DAL(1, "Test"),
                new Categorie_DAL(1, "Test2"),
            });

            var srv = new Categorie_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Categorie_DTO>>(result);

            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void Categorie_SRV_Ajouter()
        {
            var mock = new Mock<IDepot_DAL<Categorie_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Categorie_DAL>()));

            var srv = new Categorie_SRV(mock.Object);

            srv.Ajouter(new Categorie_DTO()
            {
                Id_categorie = 1,
                Nom = "Test"
            });

            mock.Verify(depot => depot.Insert(It.IsAny<Categorie_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Categorie_SRV_Modifier()
        {
            //arrange
            var mock = new Mock<IDepot_DAL<Categorie_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Categorie_DAL>()));
            var srv = new Categorie_SRV(mock.Object);

            //ACT
            srv.Modifier(new Categorie_DTO()
            {
                Id_categorie = 1,
                Nom = "Test"
            });

            //ASSERT
            mock.Verify(depot => depot.Update(It.IsAny<Categorie_DAL>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Categorie_SRV_Supprimer()
        {
            var mock = new Mock<IDepot_DAL<Categorie_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<int>()));
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Categorie_DAL(1, "Test"));

            var srv = new Categorie_SRV(mock.Object);

            srv.Supprimer(1);

            mock.Verify(depot => depot.Delete(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}