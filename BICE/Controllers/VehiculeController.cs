using BICE.DTO;
using BICE.SRV;
using Microsoft.AspNetCore.Mvc;

namespace BiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeController : Controller
    {
        //private Triangle_SRV service = new Triangle_SRV();
        private IBase_SRV<Vehicule_DTO> service;

        public VehiculeController(IBase_SRV<Vehicule_DTO> service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/Vehicule/GetById")]
        public Vehicule_DTO GetById(string id)
        {
            return service.GetById(id);
        }

        [HttpGet]
        [Route("/Vehicule/GetAll")]
        public IEnumerable<Vehicule_DTO> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost]
        [Route("/Vehicule/Ajouter")]
        public void Ajouter(Vehicule_DTO v)
        {
            service.Ajouter(v);
        }

        [HttpPost]
        [Route("/Vehicule/Modifier")]
        public void Modifier(Vehicule_DTO v)
        {
            service.Modifier(v);
        }

        [HttpPost]
        [Route("/Vehicule/Supprimer")]
        public void Supprimer(string id)
        {
            service.Supprimer(id);
        }

    }
}
