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
    }
}