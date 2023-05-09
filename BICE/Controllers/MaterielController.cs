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
        [Route("/Materiel/GetById")]
        public Materiel_DTO GetById(string id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/Materiel/GetAll")]
        public IEnumerable<Materiel_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/Materiel/Ajouter")]
        public void Ajouter(Materiel_DTO m)
        {
            service.Ajouter(m);
        }

        [HttpPost]
        [Route("/Materiel/ModifierUtiliser")]
        public void AjouterUtiliser(Materiel_DTO m)
        {
            service.ModifierRetourInterventionUtiliser(m);
        }

        [HttpPost]
        [Route("/Materiel/Modifier")]
        public void Modifier(Materiel_DTO m)
        {
            service.Modifier(m);
        }

        [HttpPost]
        [Route("/Materiel/Supprimer")]
        public void Supprimer(string id)
        {
            service.Supprimer(id);
        }

    }
}
