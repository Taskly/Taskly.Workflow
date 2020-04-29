using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkflowService.WebApi.Dto;

namespace WorkflowService.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ProjectsInfoList> GetProjectsList()
        {
            var list = new ProjectsInfoList(null);
            return Ok(list);
        }
    }
}
