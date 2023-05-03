using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterventionController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IBase_SRV<Intervention_DTO> service;

        public InterventionController(IBase_SRV<Intervention_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/Intervention/GetById")]
        public Intervention_DTO GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/Intervention/GetAll")]
        public IEnumerable<Intervention_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/Intervention/Ajouter")]
        public void Ajouter(Intervention_DTO i)
        {
            service.Ajouter(i);
        }

        [HttpPost]
        [Route("/Intervention/Modifier")]
        public void Modifier(Intervention_DTO i)
        {
            service.Modifier(i);
        }

        [HttpPost]
        [Route("/Intervention/Supprimer")]
        public void Supprimer(int id)
        {
            service.Supprimer(id);
        }

    }
}
