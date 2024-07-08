using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Task_Manger.DTO;

namespace Task_Manger.Models
{
    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
        [ForeignKey("Member")]
        public int? TeamMemberId { get; set; }
        public TeamMember Member { get; set; }


    }
    public enum TaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        OnHold = 3,
        Cancelled = 4
    }
}
