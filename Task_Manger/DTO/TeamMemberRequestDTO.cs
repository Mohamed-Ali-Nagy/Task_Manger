using System.ComponentModel.DataAnnotations;
using Task_Manger.Models;

namespace Task_Manger.DTO
{
    public class TeamMemberRequestDTO
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public TeamMember  ToTeamMember()
        {
            return new TeamMember { Name = Name, Email = Email };
        }
    }

}
