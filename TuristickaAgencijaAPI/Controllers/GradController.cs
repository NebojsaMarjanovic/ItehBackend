using DataAccessLayer.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TuristickaAgencijaAPI.Controllers
{
    [Route("[controller]")]             // ovo znaci da ce ruta biti naziv kontrolera bez Controller - znaci notes
    [ApiController]
    public class GradController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public GradController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetGradovi()
        {
            return Ok(unitOfWork.GradRepository.GetAll());
        }
        [HttpPost]
        public IActionResult AddGrad(Grad grad)
        {
            unitOfWork.GradRepository.Add(grad);
            unitOfWork.Save();

            return Ok();
        }
        [HttpGet ("{id}")]
        public IActionResult GetGrad(int id)
        {

            var grad = new Grad { GradId = id };
            return Ok(unitOfWork.GradRepository.SearchById(grad));
        }
        [HttpPut]
        public IActionResult UpdateGrad(Grad grad)
        {
            unitOfWork.GradRepository.Update(grad);
            unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGrad(int id)
        {
            var grad = new Grad { GradId = id };
            unitOfWork.GradRepository.Delete(grad);
            unitOfWork.Save();

            return Ok();
        }

    }
}
