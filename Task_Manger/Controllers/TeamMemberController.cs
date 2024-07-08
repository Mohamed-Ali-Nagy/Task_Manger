using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Manger.DTO;
using Task_Manger.Service;

namespace Task_Manger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly ITaskService _taskService;
        public TeamMemberController(ITeamMemberService teamMemberService, ITaskService taskService)
        {
            _teamMemberService = teamMemberService;
            _taskService = taskService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teamMembers = _teamMemberService.GetAll().Select(t=>t.ToTeamMemberDTO());
            return Ok(teamMembers);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var teamMember=_teamMemberService.Get(id);
            if(teamMember == null)  
                return NotFound();
            return Ok(teamMember.ToTeamMemberDTO());
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var teamMember = _teamMemberService.Get(id);
            if (teamMember == null)
                return NotFound();

            _teamMemberService.Delete(teamMember);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(TeamMemberRequestDTO teamMemberRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teamMember= _teamMemberService.Add(teamMemberRequestDTO.ToTeamMember());  
            return CreatedAtAction(nameof(GetById),new {id=teamMember.MemberId});
        }

        [HttpPut]
        public IActionResult Update(TeamMemberDTO teamMemberDTO)  
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _teamMemberService.Update(teamMemberDTO.ToTeamMember());
            return NoContent();
        }

    }
}
