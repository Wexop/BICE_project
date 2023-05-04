using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeInterventionController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IBase_SRV<VehiculeIntervention_DTO> service;

        public VehiculeInterventionController(IBase_SRV<VehiculeIntervention_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/VehiculeIntervention/GetById")]
        public VehiculeIntervention_DTO GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/VehiculeIntervention/GetAll")]
        public IEnumerable<VehiculeIntervention_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/VehiculeIntervention/Ajouter")]
        public void Ajouter(VehiculeIntervention_DTO m)
        {
            service.Ajouter(m);
        }

        [HttpPost]
        [Route("/VehiculeIntervention/Modifier")]
        public void Modifier(VehiculeIntervention_DTO m)
        {
            service.Modifier(m);
        }

        [HttpPost]
        [Route("/VehiculeIntervention/Supprimer")]
        public void Supprimer(int id)
        {
            service.Supprimer(id);
        }

    }
}
