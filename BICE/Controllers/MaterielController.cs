using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterielController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IMateriel_SRV<Materiel_DTO> service;

        public MaterielController(IMateriel_SRV<Materiel_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/GetById")]
        public Materiel_DTO GetById(string id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/GetAll")]
        public IEnumerable<Materiel_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        public Materiel_DTO Ajouter(Materiel_DTO m)
        {
            return service.Ajouter(m);
        }
    
    }
}
