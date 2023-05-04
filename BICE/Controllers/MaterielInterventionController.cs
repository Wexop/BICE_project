using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterielInterventionController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IMaterielIntervention_SRV<MaterielIntervention_DTO> service;

        public MaterielInterventionController(IMaterielIntervention_SRV<MaterielIntervention_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/MaterielIntervention/GetById")]
        public MaterielIntervention_DTO GetById(int idVehiculeIntervention, string codeBarre)
        {
            return service.GetById(idVehiculeIntervention, codeBarre);
        }

        [HttpGet]
        [Route("/MaterielIntervention/GetAll")]
        public IEnumerable<MaterielIntervention_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/MaterielIntervention/Ajouter")]
        public void Ajouter(MaterielIntervention_DTO m)
        {
            service.Ajouter(m);
        }

        [HttpPost]
        [Route("/MaterielIntervention/Modifier")]
        public void Modifier(MaterielIntervention_DTO m)
        {
            service.Modifier(m);
        }

        [HttpPost]
        [Route("/MaterielIntervention/Supprimer")]
        public void Supprimer(int idVehiculeIntervention, string codeBarre)
        {
            service.Supprimer(idVehiculeIntervention, codeBarre);
        }

    }
}
