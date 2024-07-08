
using Microsoft.EntityFrameworkCore;
using Task_Manger.Models;

namespace Task_Manger.Service
{
    public class TaskService : ITaskService
    {
        private readonly TaskMangerContext _context;
        public TaskService(TaskMangerContext context)
        {
            _context = context;
        }
        public ProjectTask Add(ProjectTask task)
        {
            _context.Add(task);
            _context.SaveChanges();
           return task;
        }

        public int Delete(ProjectTask task)
        {
             _context.Remove(task);
            return _context.SaveChanges();
        }

        public ProjectTask? Get(int id)
        {
            return _context.Tasks.Include(t=>t.Member).FirstOrDefault(t=>t.TaskId==id);
        }

        public List<ProjectTask> GetAll()
        {
            return _context.Tasks.Include(t=>t.Member).ToList();
        }

        public int Update(ProjectTask task)
        {
           _context.Update(task);
         return _context.SaveChanges();
        }
    }
}
