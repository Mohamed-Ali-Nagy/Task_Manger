using System.ComponentModel.DataAnnotations;
using Task_Manger.Models;

namespace Task_Manger.DTO
{
    public class TeamMemberDTO
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public TeamMember ToTeamMember()
        {
            return new TeamMember { Name = Name, Email = Email ,MemberId=MemberId };
        }
    }

    public static class TeamMemberExtensionMethods
    {
        public static TeamMemberDTO ToTeamMemberDTO(this TeamMember teamMember)
        {
            return new TeamMemberDTO { MemberId = teamMember.MemberId, Name = teamMember.Name, Email = teamMember.Email };
        }
    }
}

