using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Task_Manger.Models;

namespace Task_Manger.DTO
{
    public class TaskResponseDTO
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.NotStarted;
        public int? TeamMemberId { get; set; }
        public string? TeamMemberName { get; set; }
        public string? TeamMemberEmail { get; set; }

    }

    public static class ProjectTaskExtensionMethods
    {
        public static TaskResponseDTO ToTaskResponseDTO(this ProjectTask projectTask)
        {
            return new TaskResponseDTO 
            { 
                TaskId = projectTask.TaskId,
                Name = projectTask.Name,
                Description = projectTask.Description,
                StartDate = projectTask.StartDate,
                EndDate = projectTask.EndDate,
                Status = projectTask.Status,
                TeamMemberId= (projectTask.Member?.MemberId),
                TeamMemberEmail=projectTask.Member?.Email,
                TeamMemberName=projectTask.Member?.Name
            };
        }
    }
}
