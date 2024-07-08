using System.ComponentModel.DataAnnotations;
using Task_Manger.Models;

namespace Task_Manger.DTO
{
    public class TaskUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.NotStarted;
        public int TeamMemberId { get; set; }

        public ProjectTask ToProjectTask()
        {
            return new ProjectTask()
            {
                TaskId = Id,
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                TeamMemberId = TeamMemberId,
                Status = Status,
                
            };
        }
    }
}
