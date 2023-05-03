using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategorieController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IBase_SRV<Categorie_DTO> service;

        public CategorieController(IBase_SRV<Categorie_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/Categorie/GetById")]
        public Categorie_DTO GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/Categorie/GetAll")]
        public IEnumerable<Categorie_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/Categorie/Ajouter")]
        public void Ajouter(Categorie_DTO c)
        {
            service.Ajouter(c);
        }

        [HttpPost]
        [Route("/Categorie/Modifier")]
        public void Modifier(Categorie_DTO c)
        {
            service.Modifier(c);
        }

        [HttpPost]
        [Route("/Categorie/Supprimer")]
        public void Supprimer(int id)
        {
            service.Supprimer(id);
        }

    }
}
