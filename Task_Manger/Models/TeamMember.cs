using System.ComponentModel.DataAnnotations;

namespace Task_Manger.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }

        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
